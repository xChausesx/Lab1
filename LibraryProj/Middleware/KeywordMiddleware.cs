using LibraryProj.Interfaces;
using LibraryProj.Services;

public class KeywordMiddleware
{
    private readonly RequestDelegate _next;

    public KeywordMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IKeywordService keywordService)
    {
        if (context.Request.Path.StartsWithSegments("/api/keywords"))
        {
            var request = context.Request;

            if (context.Request.Path.StartsWithSegments("/api/keywords/getAll"))
            {
                var keywords = await keywordService.GetAllKeywords();

                var htmlContent = HtmlBuilderService.BuildKeywords(keywords); 

                context.Response.ContentType = "text/html";

                await context.Response.WriteAsync(htmlContent);
            }
            else if (context.Request.Path.StartsWithSegments("/api/keywords/add") && request.Method == "GET")
            {
                var formHtml = HtmlBuilderService.BuildAddForm("wwwroot/html/Keywords/addKeywords.html");

                context.Response.ContentType = "text/html";

                await context.Response.WriteAsync(formHtml);
            }
            else if (context.Request.Path.StartsWithSegments("/api/keywords/add") && request.Method == "POST")
            {
                var form = await context.Request.ReadFormAsync();

                await keywordService.AddKeywordAsync(form); 

                context.Response.Redirect("/api/keywords/getAll");
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
