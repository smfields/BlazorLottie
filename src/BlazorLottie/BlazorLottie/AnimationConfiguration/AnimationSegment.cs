using System.Text.Json.Serialization;

namespace BlazorLottie.AnimationConfiguration;

[JsonConverter(typeof(AnimationSegmentJsonConverter))]
public record AnimationSegment(int FinalFrame, int InitialFrame);