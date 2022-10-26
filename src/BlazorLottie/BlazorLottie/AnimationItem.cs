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

    /// <summary>
    /// Reference to this Dotnet object that can be passed to the JS
    /// </summary>
    private readonly DotNetObjectReference<AnimationItem> _thisReference;

    public AnimationItem(IJSObjectReference animationReference, AnimationConfig config)
    {
        Config = config;
        _animationReference = animationReference;
        _thisReference      = DotNetObjectReference.Create(this);
    }
    
    #region Events

    public event EnterFrameEventCallback?   EnterFrame
    {
        add
        {
            lock (_enterFrameCallbacks)
            {
                if (_enterFrameCallbacks.Count == 0)
                {
                    RegisterEventListener("enterFrame", nameof(OnEnterFrame));
                }
                _enterFrameCallbacks.Add(value);
            }
        }
        remove
        {
            lock (_enterFrameCallbacks)
            {
                _enterFrameCallbacks.Remove(value);
                
                if (_enterFrameCallbacks.Count == 0)
                {
                    UnregisterEventListener("enterFrame", nameof(OnEnterFrame));
                }
            }
        }
    }
    private readonly List<EnterFrameEventCallback?> _enterFrameCallbacks = new();

    public event LoopCompleteEventCallback? LoopComplete
    {
        add
        {
            lock (_loopCompleteCallbacks)
            {
                if (_loopCompleteCallbacks.Count == 0)
                {
                    RegisterEventListener("loopComplete", nameof(OnLoopComplete));
                }
                _loopCompleteCallbacks.Add(value);
            }
        }
        remove
        {
            lock (_loopCompleteCallbacks)
            {
                _loopCompleteCallbacks.Remove(value);

                if (_loopCompleteCallbacks.Count == 0)
                {
                    UnregisterEventListener("loopComplete", nameof(OnLoopComplete));
                }
            }
        }
    }
    private readonly List<LoopCompleteEventCallback?> _loopCompleteCallbacks = new();

    public event CompleteEventCallback?     Complete
    {
        add
        {
            lock (_completeCallbacks)
            {
                if (_completeCallbacks.Count == 0)
                {
                    RegisterEventListener("complete", nameof(OnComplete));
                }
                _completeCallbacks.Add(value);
            }
        }
        remove
        {
            lock (_completeCallbacks)
            {
                _completeCallbacks.Remove(value);

                if (_completeCallbacks.Count == 0)
                {
                    UnregisterEventListener("complete", nameof(OnComplete));
                }
            }
        }
    }
    private readonly List<CompleteEventCallback?> _completeCallbacks = new();

    public event SegmentStartEventCallback? SegmentStart
    {
        add
        {
            lock (_segmentStartCallbacks)
            {
                if (_segmentStartCallbacks.Count == 0)
                {
                    RegisterEventListener("segmentStart", nameof(OnSegmentStart));
                }
                _segmentStartCallbacks.Add(value);
            }
        }
        remove
        {
            lock (_segmentStartCallbacks)
            {
                _segmentStartCallbacks.Remove(value);

                if (_segmentStartCallbacks.Count == 0)
                {
                    UnregisterEventListener("segmentStart", nameof(OnSegmentStart));
                }
            }
        }
    }
    private readonly List<SegmentStartEventCallback?> _segmentStartCallbacks = new();

    public event DestroyEventCallback?      Destroyed
    {
        add
        {
            lock (_destroyedCallbacks)
            {
                if (_destroyedCallbacks.Count == 0)
                {
                    RegisterEventListener("destroy", nameof(OnDestroy));
                }
                _destroyedCallbacks.Add(value);
            }
        }
        remove
        {
            lock (_destroyedCallbacks)
            {
                _destroyedCallbacks.Remove(value);

                if (_destroyedCallbacks.Count == 0)
                {
                    UnregisterEventListener("destroy", nameof(OnDestroy));
                }
            }
        }
    }
    private readonly List<DestroyEventCallback?> _destroyedCallbacks = new();

    public event EventHandler?              ConfigReady
    {
        add
        {
            lock (_configReadyCallbacks)
            {
                if (_configReadyCallbacks.Count == 0)
                {
                    RegisterEventListener("config_ready", nameof(OnConfigReady));
                }
                _configReadyCallbacks.Add(value);
            }
        }
        remove
        {
            lock (_configReadyCallbacks)
            {
                _configReadyCallbacks.Remove(value);

                if (_configReadyCallbacks.Count == 0)
                {
                    UnregisterEventListener("config_ready", nameof(OnConfigReady));
                }
            }
        }
    }
    private readonly List<EventHandler?> _configReadyCallbacks = new();

    public event EventHandler?              DataReady
    {
        add
        {
            lock (_dataReadyCallbacks)
            {
                if (_dataReadyCallbacks.Count == 0)
                {
                    RegisterEventListener("data_ready", nameof(OnDataReady));
                }
                _dataReadyCallbacks.Add(value);
            }
        }
        remove
        {
            lock (_dataReadyCallbacks)
            {
                _dataReadyCallbacks.Remove(value);

                if (_dataReadyCallbacks.Count == 0)
                {
                    UnregisterEventListener("data_ready", nameof(OnDataReady));
                }
            }
        }
    }
    private readonly List<EventHandler?> _dataReadyCallbacks = new();

    public event EventHandler? DomLoaded
    {
        add
        {
            lock (_domLoadedCallbacks)
            {
                if (_domLoadedCallbacks.Count == 0)
                {
                    RegisterEventListener("DOMLoaded", nameof(OnDomLoaded));
                }
                _domLoadedCallbacks.Add(value);
            }
        }
        remove
        {
            lock (_domLoadedCallbacks)
            {
                _domLoadedCallbacks.Remove(value);

                if (_domLoadedCallbacks.Count == 0)
                {
                    UnregisterEventListener("DOMLoaded", nameof(OnDomLoaded));
                }
            }
        }
    }
    private readonly List<EventHandler?> _domLoadedCallbacks = new();

    public event EventHandler?              Error
    {
        add
        {
            lock (_errorCallbacks)
            {
                if (_errorCallbacks.Count == 0)
                {
                    RegisterEventListener("error", nameof(OnError));
                }
                _errorCallbacks.Add(value);
            }
        }
        remove
        {
            lock (_errorCallbacks)
            {
                _errorCallbacks.Remove(value);

                if (_errorCallbacks.Count == 0)
                {
                    UnregisterEventListener("error", nameof(OnError));
                }
            }
        }
    }
    private readonly List<EventHandler?> _errorCallbacks = new();

    public event EventHandler?              DataFailed
    {
        add
        {
            lock (_dataFailedCallbacks)
            {
                if (_dataFailedCallbacks.Count == 0)
                {
                    RegisterEventListener("data_failed", nameof(OnDataFailed));
                }
                _dataFailedCallbacks.Add(value);
            }
        }
        remove
        {
            lock (_dataFailedCallbacks)
            {
                _dataFailedCallbacks.Remove(value);

                if (_dataFailedCallbacks.Count == 0)
                {
                    UnregisterEventListener("data_failed", nameof(OnDataFailed));
                }
            }
        }
    }
    private readonly List<EventHandler?> _dataFailedCallbacks = new();

    public event EventHandler?              LoadedImages
    {
        add
        {
            lock (_loadedImagesCallbacks)
            {
                if (_loadedImagesCallbacks.Count == 0)
                {
                    RegisterEventListener("loaded_images", nameof(OnLoadedImages));
                }
                _loadedImagesCallbacks.Add(value);
            }
        }
        remove
        {
            lock (_loadedImagesCallbacks)
            {
                _loadedImagesCallbacks.Remove(value);

                if (_loadedImagesCallbacks.Count == 0)
                {
                    UnregisterEventListener("loaded_images", nameof(OnLoadedImages));
                }
            }
        }
    }
    private readonly List<EventHandler?> _loadedImagesCallbacks = new();

    [JSInvokable]
    public virtual void OnEnterFrame(BMEnterFrameEvent args)
    {
        lock (_enterFrameCallbacks)
        {
            foreach (EnterFrameEventCallback? enterFrameEventCallback in _enterFrameCallbacks)
            {
                Task.Run(() => enterFrameEventCallback?.Invoke(this, args));
            }
        }
    }
    
    [JSInvokable]
    public virtual void OnLoopComplete(BMLoopCompleteEvent args)
    {
        lock (_loopCompleteCallbacks)
        {
            foreach (LoopCompleteEventCallback? loopCompleteEventCallback in _loopCompleteCallbacks)
            {
                Task.Run(() => loopCompleteEventCallback?.Invoke(this, args));
            }
        }
    }
    
    [JSInvokable]
    public virtual void OnComplete(BMCompleteEvent args)
    {
        lock (_completeCallbacks)
        {
            foreach (CompleteEventCallback? completeEventCallback in _completeCallbacks)
            {
                Task.Run(() => completeEventCallback?.Invoke(this, args));
            }
        }
    }
    
    [JSInvokable]
    public virtual void OnSegmentStart(BMSegmentStartEvent args)
    {
        lock (_segmentStartCallbacks)
        {
            foreach (SegmentStartEventCallback? segmentStartEventCallback in _segmentStartCallbacks)
            {
                Task.Run(() => segmentStartEventCallback?.Invoke(this, args));
            }
        }
    }
    
    [JSInvokable]
    public virtual void OnDestroy(BMDestroyEvent args)
    {
        lock (_destroyedCallbacks)
        {
            foreach (DestroyEventCallback? destroyEventCallback in _destroyedCallbacks)
            {
                Task.Run(() => destroyEventCallback?.Invoke(this, args));
            }
        }
    }
        
    [JSInvokable]
    public virtual void OnConfigReady()
    {
        lock (_configReadyCallbacks)
        {
            foreach (EventHandler? configReadyCallback in _configReadyCallbacks)
            {
                Task.Run(() => configReadyCallback?.Invoke(this, EventArgs.Empty));
            }
        }
    }
    
    [JSInvokable]
    public virtual void OnDataReady()
    {
        lock (_dataReadyCallbacks)
        {
            foreach (EventHandler? dataReadyCallback in _dataReadyCallbacks)
            {
                Task.Run(() => dataReadyCallback?.Invoke(this, EventArgs.Empty));
            }
        }
    }
    
    [JSInvokable]
    public virtual void OnDomLoaded()
    {
        lock (_domLoadedCallbacks)
        {
            foreach (EventHandler? domLoadedCallback in _domLoadedCallbacks)
            {
                Task.Run(() => domLoadedCallback?.Invoke(this, EventArgs.Empty));
            }
        }
    }
    
    [JSInvokable]
    public virtual void OnError()
    {
        lock (_errorCallbacks)
        {
            foreach (EventHandler? errorCallback in _errorCallbacks)
            {
                Task.Run(() => errorCallback?.Invoke(this, EventArgs.Empty));
            }
        }
    }         
    
    [JSInvokable]                            
    public virtual void OnDataFailed()            
    {
        lock (_dataFailedCallbacks)
        {
            foreach (EventHandler? dataFailedCallback in _dataFailedCallbacks)
            {
                Task.Run(() => dataFailedCallback?.Invoke(this, EventArgs.Empty));
            }
        }
    }           
    
    [JSInvokable]                            
    public virtual void OnLoadedImages()            
    {
        lock (_loadedImagesCallbacks)
        {
            foreach (EventHandler? loadedImageCallback in _loadedImagesCallbacks)
            {
                Task.Run(() => loadedImageCallback?.Invoke(this, EventArgs.Empty));
            }
        }
    }   
    #endregion

    #region Properties

    public AnimationConfig Config { get; }

    // animationID: string;
    public ValueTask<string> AnimationId => GetValue<string>("animationID");

    // assetsPath: string;
    public ValueTask<string> AssetsPath => GetValue<string>("assetsPath");

    // autoplay: boolean;
    public ValueTask<bool> Autoplay => GetValue<bool>("autoplay");

    // currentFrame: number;
    public ValueTask<double> CurrentFrame => GetValue<double>("currentFrame");

    // currentRawFrame: number;
    public ValueTask<double> CurrentRawFrame => GetValue<double>("currentRawFrame");

    // firstFrame: number;
    public ValueTask<double> FirstFrame => GetValue<double>("firstFrame");

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
    public ValueTask<double> PlayCount => GetValue<double>("playCount");

    // playDirection: number;
    public ValueTask<AnimationDirection> PlayDirection => GetValue<AnimationDirection>("playDirection");

    // playSpeed: number;
    public ValueTask<double> PlaySpeed => GetValue<double>("playSpeed");

    // segmentPos: number;
    public ValueTask<double> SegmentPos => GetValue<double>("segmentPos");

    // segments: AnimationSegment | AnimationSegment[];
    public ValueTask<AnimationSegment[]> Segments => GetValue<AnimationSegment[]>("segments");

    // timeCompleted: number;
    public ValueTask<double> TimeCompleted => GetValue<double>("timeCompleted");

    // totalFrames: number;
    public ValueTask<double> TotalFrames => GetValue<double>("totalFrames");

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

    private ValueTask RegisterEventListener(string eventName, string callbackName)
    {
        return InvokeVoid("registerEventHandler", _thisReference, eventName, callbackName);
    }

    private ValueTask UnregisterEventListener(string eventName, string callbackName)
    {
        return InvokeVoid("unregisterEventListener", _thisReference, eventName, callbackName);
    }

    private ValueTask InvokeVoid(string identifier, params object?[]? args)
    {
        return _animationReference.InvokeVoidAsync(identifier, args);
    }

    #endregion
}