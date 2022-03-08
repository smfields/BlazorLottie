using System.Text.Json.Serialization;

namespace BlazorLottie.RendererConfiguration;

[JsonConverter(typeof(RendererEnumConverter))]
public enum Renderer
{
    SVG,
    Canvas,
    HTML
}