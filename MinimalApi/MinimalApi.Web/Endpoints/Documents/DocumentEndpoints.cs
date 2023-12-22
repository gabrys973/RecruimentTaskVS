using System.Text;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Application.Services.Documents;

namespace MinimalApi.Web.Endpoints.Documents;

public static class DocumentEndpoints
{
    public static WebApplication RegisterDocumentEndpoints(this WebApplication app)
    {
        app.MapPost("/api/test/{x}", Create).Accepts<IFormFile>("multipart/form-data");

        return app;
    }

    private static IResult Create(HttpRequest request, [FromRoute] int x, IDocumentService documentService)
    {
        if (!request.HasFormContentType || !request.Form.Files.Any())
            return Results.BadRequest(new { message = "There is no file." });

        if (request.Form.Files.Count > 1)
            return Results.BadRequest(new { message = "Cannot send more than one file." });

        var file = request.Form.Files.First();

        if (file is null || file.Length == 0)
            return Results.BadRequest(new { message = "File cannot be empty." });

        if (x < 0)
            return Results.BadRequest(new { message = "X cannot be smaller than 0." });
        
        var fileContent = new StringBuilder();
        var lineCount = 0;

        using (var reader = new StreamReader(file.OpenReadStream()))
        {
            while (reader.Peek() >= 0)
            {
                fileContent.AppendLine(reader.ReadLine());
                lineCount++;
            }
        }

        var result = documentService.ProcessFile(fileContent, lineCount, x);

        return Results.Ok(result);
    }
}