using BlazorLottie.AnimationConfiguration;

namespace BlazorLottie.RendererConfiguration;

public class CanvasRendererConfig : BaseRendererConfig
{
    public bool?                             ClearCanvas         { get; init; }
    public PreserveAspectRatioConfiguration? PreserveAspectRatio { get; init; }
    public bool?                             ProgressiveLoad     { get; init; }
}