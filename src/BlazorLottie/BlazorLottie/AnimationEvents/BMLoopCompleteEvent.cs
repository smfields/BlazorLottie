namespace BlazorLottie.AnimationEvents;

public delegate void LoopCompleteEventCallback(object? sender, BMLoopCompleteEvent args);

public class BMLoopCompleteEvent
{
    public int                CurrentLoop { get; set; }
    public bool               TotalLoops  { get; set; }
    public AnimationDirection Direction   { get; set; }
}