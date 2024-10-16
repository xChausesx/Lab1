using LibraryProj.Dto;
using LibraryProj.Models;
using MongoDB.Bson;

namespace LibraryProj.Interfaces
{
    public interface IAuthorService
    {
        public Task AddAuthorAsync(Author author);
        public Task AddAuthorAsync(IFormCollection formFile);
        public Task<List<AuthorDto>> GetAllAuthors();
        public Task<ObjectId> AddPhotoFileAsync(IFormFile file);
    }
}
