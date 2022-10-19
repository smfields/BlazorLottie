namespace BlazorLottie.AnimationEvents;

public delegate void SegmentStartEventCallback(object? sender, BMSegmentStartEvent args);

public class BMSegmentStartEvent
{
    public double FirstFrame  { get; set; }
    public double TotalFrames { get; set; }
}