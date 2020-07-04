using MongoDB.Bson.Serialization.Attributes;

namespace FuneralHome.Models
{
    public class Service
    {
        [BsonElement("serviceId")]
        public int ServiceId { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("value")]
        public decimal Value { get; set; }

        public Service() { }

        public Service(int serviceId, string name, decimal value)
        {
            ServiceId = serviceId;
            Name = name;
            Value = value;
        }
    }
}