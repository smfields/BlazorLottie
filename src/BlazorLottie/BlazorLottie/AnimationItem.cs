using System.Text.Json.Serialization;
using BlazorLottie.AnimationConfiguration;
using BlazorLottie.AnimationEvents;
using Microsoft.JSInterop;

namespace BlazorLottie;

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

    public event EnterFrameEventCallback?   EnterFrame;
    public event LoopCompleteEventCallback? LoopComplete;
    public event CompleteEventCallback?     Complete;
    public event SegmentStartEventCallback? SegmentStart;
    public event DestroyEventCallback?      Destroyed;
    public event EventHandler?              ConfigReady;
    public event EventHandler?              DataReady;
    public event EventHandler?              DomLoaded;
    public event EventHandler?              Error;
    public event EventHandler?              DataFailed;      
    public event EventHandler?              LoadedImages; 

    [JSInvokable]
    public virtual void OnEnterFrame(BMEnterFrameEvent args)
    {
        EnterFrame?.Invoke(this, args);
    }
    
    [JSInvokable]
    public virtual void OnLoopComplete(BMLoopCompleteEvent args)
    {
        LoopComplete?.Invoke(this, args);
    }
    
    [JSInvokable]
    public virtual void OnComplete(BMCompleteEvent args)
    {
        Complete?.Invoke(this, args);
    }
    
    [JSInvokable]
    public virtual void OnSegmentStart(BMSegmentStartEvent args)
    {
        SegmentStart?.Invoke(this, args);
    }
    
    [JSInvokable]
    public virtual void OnDestroy(BMDestroyEvent args)
    {
        Destroyed?.Invoke(this, args);
    }
        
    [JSInvokable]
    public virtual void OnConfigReady()
    {
        ConfigReady?.Invoke(this, EventArgs.Empty);
    }
    
    [JSInvokable]
    public virtual void OnDataReady()
    {
        DataReady?.Invoke(this, EventArgs.Empty);
    }
    
    [JSInvokable]
    public virtual void OnDomLoaded()
    {
        DomLoaded?.Invoke(this, EventArgs.Empty);
    }
    
    [JSInvokable]
    public virtual void OnError()
    {
        Error?.Invoke(this, EventArgs.Empty);
    }         
    
    [JSInvokable]                            
    public virtual void OnDataFailed()            
    {                                        
        DataFailed?.Invoke(this, EventArgs.Empty);
    }           
    
    [JSInvokable]                            
    public virtual void OnLoadedImages()            
    {                                        
        LoadedImages?.Invoke(this, EventArgs.Empty);
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