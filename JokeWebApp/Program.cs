
using Microsoft.AspNetCore.Mvc;
using JokeWebApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Include XML comments
    var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(System.IO.Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddOptions<AzureOpenAiSettings>()
    .Bind(builder.Configuration.GetSection(AzureOpenAiSettings.SectionName));

// Register the AiClient as a singleton to reuse the client instance.
builder.Services.AddSingleton<AiClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/api/getJoke", async (
    [FromBody] ChatRequestInput request,
    AiClient aiClient) => // Inject the AiClient
{
    try
    {
        var response = await aiClient.AskAiModelAsync(request.Input, request.Language);
        return Results.Ok(new JokeResponse { Response = response });
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
})
.WithName("GetJoke")
.WithSummary("Generates a joke.")
.WithDescription("Receives any user input and returns a joke based on the predefined system context for a comedy bot.")
.Produces<JokeResponse>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status500InternalServerError)
.WithOpenApi();

app.Run();

/// <summary>
/// Represents the request body for the joke generation endpoint.
/// </summary>
public class ChatRequestInput
{
    /// <summary>
    /// Any text input. The content will be ignored by the model, but the field is required.
    /// </summary>
    /// <example>Розкажи анекдот</example>
    public string Input { get; set; } = string.Empty;

    /// <summary>
    /// The language for the joke. Supported languages are Ukrainian, English, and Polish. Defaults to Ukrainian if not specified or if the specified language is not supported.
    /// </summary>
    /// <example>English</example>
    public string Language { get; set; } = Constants.DefaultLanguage;
}

/// <summary>
/// Represents the response containing the generated joke.
/// </summary>
public class JokeResponse
{
    /// <summary>
    /// The generated joke text.
    /// </summary>
    /// <example>Чому програмісти плутають Хелловін та Різдво? Тому що 31 OCT = 25 DEC.</example>
    public string? Response { get; set; }
}
