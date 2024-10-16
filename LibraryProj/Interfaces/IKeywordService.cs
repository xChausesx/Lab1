using LibraryProj.Dto;
using LibraryProj.Models;
using MongoDB.Bson;

namespace LibraryProj.Interfaces
{
    public interface IKeywordService
    {
        public Task AddKeywordAsync(Keyword keyword);
        public Task AddKeywordAsync(IFormCollection formFile);
        public Task<List<KeywordDto>> GetAllKeywords();
    }
}
