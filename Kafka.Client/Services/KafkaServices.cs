using Catalog.Kafka.Client.Interfaces;
using Catalog.Kafka.Client.Models;
using Confluent.Kafka;

namespace Catalog.Kafka.Client.Services
{
    public class KafkaServices : IKafkaServices
    {
        public void HandleDeliverReport(DeliveryReport<string, ItemUpdateEvent> deliveryReport)
        {
            if (deliveryReport.Error.Code != ErrorCode.NoError)
            {
                //log error
            }
            else
            {
                //log success
            }
        }
    }
}
