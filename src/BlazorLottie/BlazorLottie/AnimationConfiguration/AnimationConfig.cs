using BlazorLottie.RendererConfiguration;
using Microsoft.AspNetCore.Components;

namespace BlazorLottie.AnimationConfiguration;

public abstract class AnimationConfig
{
    public string?               AssetsPath       { get; init; }
    public bool?                 Autoplay         { get; init; }
    public ElementReference      Container        { get; }
    public AnimationSegment?     InitialSegment   { get; init; }
    public LoopingConfiguration? Loop             { get; init; }
    public string?               Name             { get; init; }
    public Renderer              Renderer         { get; init; }
    public BaseRendererConfig?   RendererSettings { get; init; }

    public AnimationConfig(ElementReference container)
    {
        Container = container;
    }
}