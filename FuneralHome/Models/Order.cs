using System;
using MongoDB.Bson.Serialization.Attributes;

namespace FuneralHome.Models
{
    public class Order
    {
        [BsonElement("orderId")]
        public int OrderId { get; set; }
        [BsonElement("client")]
        public Client Client { get; set; }
        [BsonElement("employee")]
        public Employee Employee { get; set; }
        [BsonElement("funeral")]
        public Funeral Funeral { get; set; }
        [BsonElement("service")]
        public Service Service { get; set; }
        [BsonElement("date")]
        public DateTime Date { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }

        public Order() { }

        public Order(int orderId, Client client, Employee employee, Funeral funeral, 
            Service service, DateTime date, string description)
        {
            OrderId = orderId;
            Client = client;
            Employee = employee;
            Funeral = funeral;
            Service = service;
            Date = date;
            Description = description;
        }
    }
}