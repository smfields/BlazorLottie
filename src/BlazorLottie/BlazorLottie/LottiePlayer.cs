using BlazorLottie.AnimationConfiguration;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorLottie;

public class LottiePlayer : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public LottiePlayer(IJSRuntime jsRuntime)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/BlazorLottie/lottie-interop.js").AsTask());
    }

    #region IAsyncDisposable Members

    public async ValueTask DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            IJSObjectReference module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }

    #endregion

    public async ValueTask Destroy(string? name = null)
    {
        IJSObjectReference module = await _moduleTask.Value;
        await module.InvokeVoidAsync("destroy", name);
    }

    public async ValueTask<AnimationItem> LoadAnimation(ElementReference container, AnimationConfig config)
    {
        IJSObjectReference module                   = await _moduleTask.Value;
        var                jsAnimationReference     = await module.InvokeAsync<IJSObjectReference>("loadAnimation", container, config);
        var                animationItem            = new AnimationItem(jsAnimationReference, config);
        return animationItem;
    }

    public async ValueTask Pause(string? name = null)
    {
        IJSObjectReference module = await _moduleTask.Value;
        await module.InvokeVoidAsync("pause", name);
    }

    public async ValueTask Play(string? name = null)
    {
        IJSObjectReference module = await _moduleTask.Value;
        await module.InvokeVoidAsync("play", name);
    }

    public async ValueTask RegisterAnimation(ElementReference element, object? animationData = null)
    {
        IJSObjectReference module = await _moduleTask.Value;
        await module.InvokeVoidAsync("registerAnimation", element, animationData);
    }

    public async ValueTask SearchAnimations(object? animationData = null, bool? standalone = null, string? renderer = null)
    {
        IJSObjectReference module = await _moduleTask.Value;
        await module.InvokeVoidAsync("searchAnimations", animationData, standalone, renderer);
    }

    public async ValueTask SetDirection(AnimationDirection direction, string? name = null)
    {
        IJSObjectReference module = await _moduleTask.Value;
        await module.InvokeVoidAsync("setDirection", direction, name);
    }

    public async ValueTask SetIdPrefix(string prefix)
    {
        IJSObjectReference module = await _moduleTask.Value;
        await module.InvokeVoidAsync("setIdPrefix", prefix);
    }

    public async ValueTask SetLocationHref(string href)
    {
        IJSObjectReference module = await _moduleTask.Value;
        await module.InvokeVoidAsync("setLocationHref", href);
    }

    public async ValueTask SetQuality(string quality)
    {
        IJSObjectReference module = await _moduleTask.Value;
        await module.InvokeVoidAsync("setQuality", quality);
    }

    public async ValueTask SetQuality(double quality)
    {
        IJSObjectReference module = await _moduleTask.Value;
        await module.InvokeVoidAsync("setQuality", quality);
    }

    public async ValueTask SetSpeed(double speed, string? name = null)
    {
        IJSObjectReference module = await _moduleTask.Value;
        await module.InvokeVoidAsync("setSpeed", speed, name);
    }

    public async ValueTask Stop(string? name = null)
    {
        IJSObjectReference module = await _moduleTask.Value;
        await module.InvokeVoidAsync("stop", name);
    }
}