namespace BlazorLottie.AnimationEvents;

public delegate void DestroyEventCallback(object? sender, BMDestroyEvent args);

public class BMDestroyEvent
{
    public AnimationItem Target { get; set; }
}