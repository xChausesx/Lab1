using LibraryProj.Interfaces;
using LibraryProj.Models;
using LibraryProj.Services;
using MongoDB.Bson.IO;

public class BookMiddleware
{
    private readonly RequestDelegate _next;

    public BookMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/books"))
        {
            var request = context.Request;

            if (request.Method == "POST")
            {
                var body = await new StreamReader(request.Body).ReadToEndAsync();

                await _next(context);
            }
            else if (request.Method == "GET")
            {
/*                var bookService = new BookService(context);

                var books = bookService.GetBooksAsync();*//*

                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(books);*/
            }
            else
            {
                await _next(context);
            }
        }
        else
        {
            await _next(context);
        }
    }
}
