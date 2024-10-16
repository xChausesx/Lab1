using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace LibraryProj.Dto
{
    public class AuthorDto
    {
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(48)]
        public string ShortName { get; set; }

        public string Bio { get; set; }

        [MaxLength(200)]
        public byte[] Photo { get; set; }
    }
}
