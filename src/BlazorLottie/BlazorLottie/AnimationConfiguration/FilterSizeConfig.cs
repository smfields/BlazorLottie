namespace BlazorLottie.AnimationConfiguration;

public class FilterSizeConfig
{
    public string Height { get; }
    public string Width  { get; }
    public string X      { get; }
    public string Y      { get; }

    public FilterSizeConfig(string width, string height, string x, string y)
    {
        Width  = width;
        Height = height;
        X      = x;
        Y      = y;
    }
}