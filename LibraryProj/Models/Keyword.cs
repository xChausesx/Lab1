using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace LibraryProj.Models
{
    public class Keyword
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [MaxLength(48)]
        public string Word { get; set; }

        public Keyword() { }
    }
}
