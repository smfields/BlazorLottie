namespace BlazorLottie.AnimationConfiguration;

public class PreserveAspectRatioConfiguration
{
    public AlignmentValue AlignmentValue { get; }
    public MeetOrSlice?   MeetOrSlice    { get; }

    public PreserveAspectRatioConfiguration(AlignmentValue alignmentValue, MeetOrSlice? meetOrSlice = null)
    {
        AlignmentValue = alignmentValue;
        MeetOrSlice    = meetOrSlice;
    }
}