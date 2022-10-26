namespace BlazorLottie.AnimationEvents;

public delegate void AnimationConfigErrorEventCallback(object? sender, BMAnimationConfigErrorEvent args);

public class BMAnimationConfigErrorEvent
{
    public dynamic NativeError { get; init; }
    public double  CurrentTime { get; init; }
}