using LibraryProj.Dto;
using LibraryProj.Interfaces;
using LibraryProj.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace LibraryProj.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IMongoDatabase _dbContext;
        private readonly GridFSBucket _gridFS;
        public AuthorService(IMongoDatabase dbContext)
        {
            _dbContext = dbContext;
            _gridFS = new(dbContext);
        }
        public async Task AddAuthorAsync(Author author)
        {
            await _dbContext.GetCollection<Author>("Authors").InsertOneAsync(author);
        }
        public async Task AddAuthorAsync(IFormCollection formFile)
        {
            var fullName = formFile["FullName"];
            var shortName = formFile["ShortName"];
            var bio = formFile["Bio"];

            if(formFile.Files.Any())
            {
                IFormFile photo = formFile.Files[0];

                var fileId = await AddPhotoFileAsync(photo);

                var newAuthor = new Author
                {
                    FullName = fullName,
                    ShortName = shortName,
                    Bio = bio,
                    PhotoId = fileId
                };
                await AddAuthorAsync(newAuthor);
            }
            else
            {
                var newAuthor = new Author
                {
                    FullName = fullName,
                    ShortName = shortName,
                    Bio = bio
                };
                await AddAuthorAsync(newAuthor);
            }
        }

        public async Task<List<AuthorDto>> GetAllAuthors()
        {
            var authors = _dbContext.GetCollection<Author>("Authors").AsQueryable().ToList();

            var authorDtos = new List<AuthorDto>();

            foreach (var author in authors)
            {
                var photo = author.PhotoId != ObjectId.Empty ? await GetFileByIdAsync(author.PhotoId) : null;

                var authorDto = new AuthorDto
                {
                    FullName = author.FullName,
                    ShortName = author.ShortName,
                    Bio = author.Bio,
                    Photo = photo
                };

                authorDtos.Add(authorDto);
            }

            return authorDtos;
        }

        public async Task<ObjectId> AddPhotoFileAsync(IFormFile file)
        {
            ObjectId fileId = ObjectId.Empty;

            if (file != null && file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                fileId = await _gridFS.UploadFromStreamAsync(file.FileName, stream);
            }

            return fileId;
        }

        private async Task<byte[]> GetFileByIdAsync(ObjectId objectId)
        {
            var fileStream = await _gridFS.OpenDownloadStreamAsync(objectId);

            using var memoryStream = new MemoryStream();
            await fileStream.CopyToAsync(memoryStream);

            return memoryStream.ToArray();
        }
    }
}
