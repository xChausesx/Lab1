using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace LibraryProj.Dto
{
    public class KeywordDto
    {
        [MaxLength(48)]
        public string Word { get; set; }
    }
}
