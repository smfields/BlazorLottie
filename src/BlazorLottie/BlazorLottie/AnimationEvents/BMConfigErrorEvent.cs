namespace BlazorLottie.AnimationEvents;

public delegate void ConfigErrorEventCallback(object? sender, BMConfigErrorEvent args);

public class BMConfigErrorEvent
{
    public dynamic NativeError { get; set; }
}