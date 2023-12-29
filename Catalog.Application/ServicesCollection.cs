using Catalog.Application.Interfaces;
using Catalog.Application.Services;
using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Confluent.SchemaRegistry.Serdes;
using Confluent.Kafka.SyncOverAsync;
using Catalog.Kafka.Client.Models;

namespace Catalog.Application
{
    public static class ServicesCollection
    {
        public static void AddApplicationLayerServices(this IServiceCollection services)
        {
            services.AddScoped<IItemsService, ItemsService>();
            services.AddScoped<ICategoriesService, CategoryService>();
            services.AddAutoMapper(typeof(RepoDomainMappingProfile));

            services.AddSingleton<ISchemaRegistryClient>(sp =>
            {
                var schemaRegistryClient = sp.GetRequiredService<IOptions<SchemaRegistryConfig>>();

                return new CachedSchemaRegistryClient(schemaRegistryClient.Value);
            });

            services.AddSingleton<IProducer<string, ItemUpdateEvent>>(sp =>
            {
                var config = sp.GetRequiredService<IOptions<ProducerConfig>>();
                var schemaRegistry = sp.GetRequiredService<ISchemaRegistryClient>();

                return new ProducerBuilder<string, ItemUpdateEvent>(config.Value)
                        .SetValueSerializer(new AvroSerializer<ItemUpdateEvent>(schemaRegistry).AsSyncOverAsync())
                        .Build();
            });

            services.AddSingleton(sp =>
            {
                var config = sp.GetRequiredService<IOptions<ProducerConfig>>();
                return new ProducerBuilder<string, int>(config.Value).Build();
            });
        }
    }
}
