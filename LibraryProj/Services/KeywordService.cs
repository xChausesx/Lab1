using LibraryProj.Dto;
using LibraryProj.Interfaces;
using LibraryProj.Models;
using MongoDB.Driver;

namespace LibraryProj.Services
{
    public class KeywordService : IKeywordService
    {
        private readonly IMongoDatabase _dbContext;
        public KeywordService(IMongoDatabase dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddKeywordAsync(Keyword keyword)
        {
            await _dbContext.GetCollection<Keyword>("Keywords").InsertOneAsync(keyword);
        }

        public async Task AddKeywordAsync(IFormCollection formFile)
        {
            var word = formFile["Word"];

            var newKeyword = new Keyword
            {
                Word = word
            };

            await AddKeywordAsync(newKeyword);
        }

        public async Task<List<KeywordDto>> GetAllKeywords()
        {
            var keywords = await _dbContext.GetCollection<Keyword>("Keywords").Find(FilterDefinition<Keyword>.Empty).ToListAsync();

            var keywordDtos = keywords.Select(k => new KeywordDto
            {
                Word = k.Word
            }).ToList();

            return keywordDtos;
        }
    }
}
