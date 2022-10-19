namespace BlazorLottie.AnimationEvents;

public delegate void RenderFrameErrorEventCallback(object? sender, BMRenderFrameErrorEvent args);

public class BMRenderFrameErrorEvent
{
    public dynamic NativeError { get; set; }
    public double  CurrentTime { get; set; }
}