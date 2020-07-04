using MongoDB.Bson.Serialization.Attributes;

namespace FuneralHome.Models
{
    public class Client
    {
        [BsonElement("clientId")]
        public int ClientId { get; set; }
        [BsonElement("firstName")]
        public string FirstName { get; set; }
        [BsonElement("lastName")]
        public string LastName { get; set; }
        [BsonElement("pesel")]
        public string Pesel { get; set; }

        public Client() { }

        public Client(int clientId, string firstName, string lastName, string pesel)
        {
            ClientId = clientId;
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
        }
    }
}