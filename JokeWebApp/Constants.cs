
namespace JokeWebApp;

/// <summary>
/// Contains constant values used throughout the application.
/// </summary>
public static class Constants
{
    /// <summary>
    /// The default name of the AI model deployment.
    /// </summary>
    public const string DefaultModelDeploymentName = "jester";

    /// <summary>
    /// Defines the default language for joke generation.
    /// </summary>
    public const string DefaultLanguage = "Ukrainian";

    /// <summary>
    /// A collection of supported languages for joke generation.
    /// </summary>
    public static readonly IReadOnlySet<string> SupportedLanguages = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        "Ukrainian",
        "English",
        "Polish"
    };
}
