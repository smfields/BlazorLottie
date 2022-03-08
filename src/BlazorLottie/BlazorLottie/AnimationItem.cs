using System.Text.Json.Serialization;
using BlazorLottie.AnimationConfiguration;
using Microsoft.JSInterop;

namespace BlazorLottie;

public delegate void AnimationEventCallback(dynamic args);

public class AnimationItem
{
    /// <summary>
    /// Reference to the JS animation item object
    /// </summary>
    private readonly IJSObjectReference _animationReference;

    public AnimationItem(IJSObjectReference animationReference)
    {
        _animationReference = animationReference;
    }
    
    #region Events

    public event AnimationEventCallback? EnterFrame;

    // addEventListener<T = any>(name: AnimationEventName, callback: AnimationEventCallback<T>): () => void;
    public void AddEventListener<T>(AnimationEventName animationEventName, AnimationEventCallback callback)
    {
        switch (animationEventName)
        {
            case AnimationEventName.EnterFrame:
                EnterFrame += callback;
                break;
            case AnimationEventName.LoopComplete:
                break;
            case AnimationEventName.Complete:
                break;
            case AnimationEventName.SegmentStart:
                break;
            case AnimationEventName.Destroy:
                break;
            case AnimationEventName.ConfigReady:
                break;
            case AnimationEventName.DataReady:
                break;
            case AnimationEventName.DomLoaded:
                break;
            case AnimationEventName.Error:
                break;
            case AnimationEventName.DataFailed:
                break;
            case AnimationEventName.LoadedImages:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(animationEventName), animationEventName, null);
        }
    }
    
    // removeEventListener<T = any>(name: AnimationEventName, callback?: AnimationEventCallback<T>): void;
    public void RemoveEventListener<T>(AnimationEventName animationEventName, AnimationEventCallback? callback = null)
    {
        switch (animationEventName)
        {
            case AnimationEventName.EnterFrame:
                EnterFrame -= callback;
                break;
            case AnimationEventName.LoopComplete:
                break;
            case AnimationEventName.Complete:
                break;
            case AnimationEventName.SegmentStart:
                break;
            case AnimationEventName.Destroy:
                break;
            case AnimationEventName.ConfigReady:
                break;
            case AnimationEventName.DataReady:
                break;
            case AnimationEventName.DomLoaded:
                break;
            case AnimationEventName.Error:
                break;
            case AnimationEventName.DataFailed:
                break;
            case AnimationEventName.LoadedImages:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(animationEventName), animationEventName, null);
        }
    }
    
    // triggerEvent<T = any>(name: AnimationEventName, args: T): void;
    [JSInvokable]
    public void TriggerEvent(AnimationEventName animationEventName, dynamic args)
    {
        switch (animationEventName)
        {
            case AnimationEventName.EnterFrame:
                EnterFrame?.Invoke(args);
                break;
            case AnimationEventName.LoopComplete:
                break;
            case AnimationEventName.Complete:
                break;
            case AnimationEventName.SegmentStart:
                break;
            case AnimationEventName.Destroy:
                break;
            case AnimationEventName.ConfigReady:
                break;
            case AnimationEventName.DataReady:
                break;
            case AnimationEventName.DomLoaded:
                break;
            case AnimationEventName.Error:
                break;
            case AnimationEventName.DataFailed:
                break;
            case AnimationEventName.LoadedImages:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(animationEventName), animationEventName, null);
        }
    }

    #endregion

    #region Properties

    // renderer: any;
    // TODO

    // animationID: string;
    public ValueTask<string> AnimationId => GetValue<string>("animationID");

    // assetsPath: string;
    public ValueTask<string> AssetsPath => GetValue<string>("assetsPath");

    // autoplay: boolean;
    public ValueTask<bool> Autoplay => GetValue<bool>("autoplay");

    // currentFrame: number;
    public ValueTask<int> CurrentFrame => GetValue<int>("currentFrame");

    // currentRawFrame: number;
    public ValueTask<int> CurrentRawFrame => GetValue<int>("currentRawFrame");

    // firstFrame: number;
    public ValueTask<int> FirstFrame => GetValue<int>("firstFrame");

    // frameMult: number;
    [JsonPropertyName("frameMult")]
    public ValueTask<double> FrameMultiplier => GetValue<double>("frameMult");

    // frameRate: number;
    public ValueTask<double> FrameRate => GetValue<double>("frameRate");

    // isLoaded: boolean;
    public ValueTask<bool> IsLoaded => GetValue<bool>("isLoaded");

    // isPaused: boolean;
    public ValueTask<bool> IsPaused => GetValue<bool>("isPaused");

    // isSubframeEnabled: boolean;
    public ValueTask<bool> IsSubframeEnabled => GetValue<bool>("isSubframeEnabled");

    // loop: boolean | number;
    public ValueTask<LoopingConfiguration> Loop => GetValue<LoopingConfiguration>("loop");

    // name: string;
    public ValueTask<string> Name => GetValue<string>("name");

    // playCount: number;
    public ValueTask<int> PlayCount => GetValue<int>("playCount");

    // playDirection: number;
    public ValueTask<AnimationDirection> PlayDirection => GetValue<AnimationDirection>("playDirection");

    // playSpeed: number;
    public ValueTask<double> PlaySpeed => GetValue<double>("playSpeed");

    // segmentPos: number;
    public ValueTask<int> SegmentPos => GetValue<int>("segmentPos");

    // segments: AnimationSegment | AnimationSegment[];
    public ValueTask<AnimationSegment[]> Segments => GetValue<AnimationSegment[]>("segments");

    // timeCompleted: number;
    public ValueTask<int> TimeCompleted => GetValue<int>("timeCompleted");

    // totalFrames: number;
    public ValueTask<int> TotalFrames => GetValue<int>("totalFrames");
    
    /// <summary>
    /// Returns the value of the property on the JS animation item object
    /// </summary>
    /// <param name="propertyName">The name of the property</param>
    /// <typeparam name="T">The type of the property</typeparam>
    /// <returns>The value of the property on the JS animation item object</returns>
    private ValueTask<T> GetValue<T>(string propertyName)
    {
        return _animationReference.InvokeAsync<T>("getProperty", propertyName);
    }

    #endregion

    #region Methods

     // destroy(name?: string): void;
    public ValueTask Destroy()
    {
        return InvokeVoid("destroy");
    }

    // getDuration(inFrames?: boolean): number;
    public ValueTask GetDuration(bool? inFrames = null)
    {
        return InvokeVoid("getDuration", inFrames);
    }

    // goToAndPlay(value: number, isFrame?: boolean, name?: string): void;
    public ValueTask GoToAndPlay(int value, bool? isFrame = null)
    {
        return InvokeVoid("goToAndPlay", value, isFrame);
    }

    // goToAndStop(value: number, isFrame?: boolean, name?: string): void;
    public ValueTask GoToAndStop(int number, bool? isFrame = null)
    {
        return InvokeVoid("goToAndStop", number, isFrame);
    }

    // hide(): void;
    public ValueTask Hide()
    {
        return InvokeVoid("hide");
    }

    // includeLayers(data: any): void;
    public ValueTask IncludeLayers(object? data)
    {
        return InvokeVoid("includeLayers", data);
    }

    // pause(name?: string): void;
    public ValueTask Pause()
    {
        return InvokeVoid("pause");
    }

    // play(name?: string): void;
    public ValueTask Play()
    {
        return InvokeVoid("play");
    }

    // playSegments(segments: AnimationSegment | AnimationSegment[], forceFlag?: boolean): void;
    public ValueTask PlaySegments(AnimationSegment[] segments, bool? forceFlag = null)
    {
        return InvokeVoid("playSegments", segments, forceFlag);
    }

    // resetSegments(forceFlag: boolean): void;
    public ValueTask ResetSegments(bool forceFlag)
    {
        return InvokeVoid("resetSegments", forceFlag);
    }

    // resize(): void;
    public ValueTask Resize()
    {
        return InvokeVoid("resize");
    }

    // setDirection(direction: AnimationDirection): void;
    public ValueTask SetDirection(AnimationDirection direction)
    {
        return InvokeVoid("setDirection", direction);
    }

    // setSegment(init: number, end: number): void;
    public ValueTask SetSegment(int init, int end)
    {
        return InvokeVoid("setSegment", init, end);
    }

    // setSpeed(speed: number): void;
    public ValueTask SetSpeed(double speed)
    {
        return InvokeVoid("setSpeed", speed);
    }

    // setSubframe(useSubFrames: boolean): void;
    public ValueTask SetSubframe(bool useSubFrames)
    {
        return InvokeVoid("setSubframe", useSubFrames);
    }

    // show(): void;
    public ValueTask Show()
    {
        return InvokeVoid("show");
    }

    // stop(name?: string): void;
    public ValueTask Stop()
    {
        return InvokeVoid("stop");
    }

    // togglePause(name?: string): void;
    public ValueTask TogglePause()
    {
        return InvokeVoid("togglePause");
    }

    private ValueTask InvokeVoid(string identifier, params object?[]? args)
    {
        return _animationReference.InvokeVoidAsync(identifier, args);
    }

    #endregion
}