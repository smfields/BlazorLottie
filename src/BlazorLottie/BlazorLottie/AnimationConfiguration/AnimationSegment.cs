using System.Text.Json.Serialization;

namespace BlazorLottie.AnimationConfiguration;

[JsonConverter(typeof(AnimationSegmentJsonConverter))]
public class AnimationSegment
{
    public int FinalFrame   { get; }
    public int InitialFrame { get; }

    public AnimationSegment(int initialFrame, int finalFrame)
    {
        InitialFrame = initialFrame;
        FinalFrame   = finalFrame;
    }
}