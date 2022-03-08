using Microsoft.AspNetCore.Components;

namespace BlazorLottie.AnimationConfiguration;

public class AnimationConfigWithData : AnimationConfig
{
    public object AnimationData { get; init; }

    public AnimationConfigWithData(ElementReference container, object animationData) : base(container)
    {
        AnimationData = animationData;
    }
}