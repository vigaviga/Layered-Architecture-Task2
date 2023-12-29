using Catalog.Kafka.Client.Models;
using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Kafka.Client.Interfaces
{
    public interface IKafkaServices
    {
        void HandleDeliverReport(DeliveryReport<string, ItemUpdateEvent> deliveryReport);
    }
}
