using LibraryProj.Interfaces;
using LibraryProj.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

string? connectionUri = Environment.GetEnvironmentVariable("LibraryDatabase");

var client = new MongoClient(connectionUri);

builder.Services.AddSingleton(client.GetDatabase("LibraryDatabase"));

builder.Services.AddTransient<IBookService,BookService>();
builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddTransient<IKeywordService, KeywordService>();

var app = builder.Build();

app.UseStaticFiles();

app.UseMiddleware<BookMiddleware>();
app.UseMiddleware<AuthorMiddleware>();
app.UseMiddleware<KeywordMiddleware>();

app.Run();