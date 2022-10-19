namespace BlazorLottie.AnimationEvents;

public delegate void EnterFrameEventCallback(object? sender, BMEnterFrameEvent args);

public class BMEnterFrameEvent
{
    public double             CurrentTime { get; set; }
    public double             TotalTime   { get; set; }
    public AnimationDirection Direction   { get; set; }
}