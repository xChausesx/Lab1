using LibraryProj.Dto;
using LibraryProj.Models;
using MongoDB.Bson;
using System.Text;

namespace LibraryProj.Services
{
    public static class HtmlBuilderService
    {
        public static string BuildAuthors(List<AuthorDto> authors)
        {
            var htmlTemplate = File.ReadAllText("wwwroot/html/Authors/allAuthors.html");

            var htmlBuilder = new StringBuilder();

            foreach (var author in authors)
            {
                htmlBuilder.Append("<li>");
                htmlBuilder.Append($"<h2>{author.FullName}</h2>");
                htmlBuilder.Append($"<p><strong>Short Name:</strong> {author.ShortName}</p>");
                htmlBuilder.Append($"<p><strong>Bio:</strong> {author.Bio}</p>");

                if (author.Photo != null && author.Photo.Length > 0)
                {
                    var base64String = Convert.ToBase64String(author.Photo);
                    htmlBuilder.Append($"<img src=\"data:image/jpeg;base64,{base64String}\" alt=\"{author.FullName}\" style=\"width:150px;height:150px;\">");
                }
                else
                {
                    htmlBuilder.Append("<p>No photo available</p>");
                }

                htmlBuilder.Append("</li>");
            }

            return htmlTemplate.Replace("<!-- list -->", htmlBuilder.ToString());
        }
        public static string BuildKeywords(List<KeywordDto> keywords)
        {
            var htmlTemplate = File.ReadAllText("wwwroot/html/Keywords/allKeywords.html");

            var htmlBuilder = new StringBuilder();

            foreach (var keyword in keywords)
            {
                htmlBuilder.Append("<li>");
                htmlBuilder.Append($"<h2>{keyword.Word}</h2>");
                htmlBuilder.Append("</li>");
            }

            return htmlTemplate.Replace("<!-- list -->", htmlBuilder.ToString());
        }
        public static string BuildAddForm(string path)
        {
            var htmlTemplate = File.ReadAllText(path);

            return htmlTemplate.ToString();
        }
    }
}
