using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using LibraryProj.Dto;

namespace LibraryProj.Models
{
    public class Book
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        
        [Required]
        public int Pages { get; set; }
        public ObjectId? FileId { get; set; }   
        public ObjectId[]? Authors { get; set; }
        public ObjectId[]? Keywords { get; set; }

        public Book() { }

        public Book(BookDto bookDto)
        {
            Title=bookDto.Title;
            Pages=bookDto.Pages;
        }
    }
}
