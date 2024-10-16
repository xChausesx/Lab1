using LibraryProj.Dto;
using LibraryProj.Models;

namespace LibraryProj.Interfaces
{
    public interface IBookService
    {
        public Task AddBookAsync(Book book);
        public Task AddBookAsync(IFormCollection formFile);
        public Task<List<Book>> GetAllBooks();
    }
}
