namespace BlazorLottie.AnimationEvents;

public delegate void AnimationConfigErrorEventCallback(object? sender, BMAnimationConfigErrorEvent args);

public class BMAnimationConfigErrorEvent
{
    public dynamic NativeError { get; set; }
    public double  CurrentTime { get; set; }
}