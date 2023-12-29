using Catalog.Kafka.Client.Interfaces;
using Catalog.Kafka.Client.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Kafka.Client
{
    public static class KafkaServiceCollection
    {
        public static IServiceCollection AddKafkaServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IKafkaServices, KafkaServices>();
            return serviceCollection;
        }
    }
}
