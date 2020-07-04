using MongoDB.Bson.Serialization.Attributes;

namespace FuneralHome.Models
{
    public class Funeral
    {
        [BsonElement("funeralId")]
        public int FuneralId { get; set; }
        [BsonElement("funeralPerson")]
        public string FuneralPerson { get; set; }
        [BsonElement("value")]
        public decimal Value { get; set; }

        public Funeral() { }

        public Funeral(int funeralId, string funeralPerson, decimal value)
        {
            FuneralId = funeralId;
            FuneralPerson = funeralPerson;
            Value = value;
        }
    }
}