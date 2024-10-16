using LibraryProj.Interfaces;
using LibraryProj.Services;

public class AuthorMiddleware
{
    private readonly RequestDelegate _next;

    public AuthorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IAuthorService authorService)
    {
        if (context.Request.Path.StartsWithSegments("/api/authors"))
        {
            var request = context.Request;

            if (context.Request.Path.StartsWithSegments("/api/authors/getAll"))
            {
                var authors = await authorService.GetAllAuthors();

                var htmlContent = HtmlBuilderService.BuildAuthors(authors);

                context.Response.ContentType = "text/html";

                await context.Response.WriteAsync(htmlContent);

            }
            else if (context.Request.Path.StartsWithSegments("/api/authors/add") && request.Method == "GET")
            {
                var formHtml = HtmlBuilderService.BuildAddForm("wwwroot/html/Authors/addAuthors.html");

                context.Response.ContentType = "text/html";

                await context.Response.WriteAsync(formHtml);
            }
            else if (context.Request.Path.StartsWithSegments("/api/authors/add") && request.Method == "POST")
            {
                var form = await context.Request.ReadFormAsync();

                await authorService.AddAuthorAsync(form);

                context.Response.Redirect("/api/authors/getAll");
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
