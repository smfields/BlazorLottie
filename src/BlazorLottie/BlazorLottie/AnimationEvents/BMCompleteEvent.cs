namespace BlazorLottie.AnimationEvents;

public delegate void CompleteEventCallback(object? sender, BMCompleteEvent args);

public class BMCompleteEvent
{
    public AnimationDirection Direction   { get; set; }
}