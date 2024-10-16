using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace LibraryProj.Models
{
    public class Author
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(48)]
        public string ShortName { get; set; }

        public string Bio { get; set; }

        [MaxLength(200)]
        public ObjectId PhotoId { get; set; }
    }
}
