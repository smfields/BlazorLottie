namespace BlazorLottie.RendererConfiguration;

public record HTMLRendererConfig : BaseRendererConfig
{
    public bool? HideOnTransparent { get; init; }
}