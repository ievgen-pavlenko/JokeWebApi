namespace JokeWebApp;

/// <summary>
/// Represents the configuration settings for the Azure OpenAI service.
/// </summary>
public class AzureOpenAiSettings
{
    /// <summary>
    /// The configuration section name.
    /// </summary>
    public const string SectionName = "AzureOpenAI";

    /// <summary>
    /// The endpoint URL for the Azure OpenAI service.
    /// </summary>
    public string Endpoint { get; set; } = string.Empty;

    /// <summary>
    /// The API key for authenticating with the Azure OpenAI service.
    /// </summary>
    public string ApiKey { get; set; } = string.Empty;

    /// <summary>
    /// The name of the model deployment to use.
    /// </summary>
    public string ModelDeploymentName { get; set; } = Constants.DefaultModelDeploymentName;
}
