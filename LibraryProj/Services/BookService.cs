using LibraryProj.Dto;
using LibraryProj.Interfaces;
using LibraryProj.Models;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;
using MongoDbGenericRepository;
using System.Net.Http;

namespace LibraryProj.Services
{
    public class BookService : IBookService
    {
        private readonly IMongoDatabase _dbContext;
        public async Task<List<Book>> GetAllBooks()
        {
            var books = await _dbContext.GetCollection<Book>("Books").AsQueryable().ToListAsync();

            return books;
        }
        public async Task AddBookAsync(BookDto bookDto)
        {


            return;
        }

        public Task AddBookAsync(Keyword keyword)
        {
            throw new NotImplementedException();
        }

        public Task AddBookAsync(IFormCollection formFile)
        {
            throw new NotImplementedException();
        }

        public Task AddBookAsync(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
