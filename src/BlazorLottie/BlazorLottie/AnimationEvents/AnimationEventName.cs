using System.Text.Json.Serialization;

namespace BlazorLottie.AnimationEvents;

[JsonConverter(typeof(AnimationEventNameEnumConverter))]
public enum AnimationEventName
{
    EnterFrame,
    LoopComplete,
    Complete,
    SegmentStart,
    Destroy,
    ConfigReady,
    DataReady,
    DomLoaded,
    Error,
    DataFailed,
    LoadedImages
}