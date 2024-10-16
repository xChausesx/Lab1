using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using LibraryProj.Models;

namespace LibraryProj.Dto
{
    public class BookDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public int Pages { get; set; }
        public byte[] File { get; set; }
        public string[] Authors { get; set; }
        public string[] Keywords { get; set; }
    }
}
