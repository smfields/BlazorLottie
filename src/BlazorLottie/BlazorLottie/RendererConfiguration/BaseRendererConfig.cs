using System.Text.Json.Serialization;
using BlazorLottie.AnimationConfiguration;

namespace BlazorLottie.RendererConfiguration;

[JsonConverter(typeof(RendererConfigJsonConverter))]
public abstract class BaseRendererConfig
{
    public string?                           ClassName                { get; init; }
    public PreserveAspectRatioConfiguration? ImagePreserveAspectRatio { get; init; }
}