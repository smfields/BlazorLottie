using Microsoft.AspNetCore.Components;

namespace BlazorLottie.AnimationConfiguration;

public class AnimationConfigWithPath : AnimationConfig
{
    public string Path { get; }

    public AnimationConfigWithPath(ElementReference container, string path) : base(container)
    {
        Path = path;
    }
}