using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorLottie.AnimationEvents;

internal class AnimationEventNameEnumConverter : JsonStringEnumConverter
{
    public AnimationEventNameEnumConverter() : base(new AnimationEventNamingPolicy())
    {
    }

    #region Nested type: AnimationEventNamingPolicy

    private class AnimationEventNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return name switch
            {
                "EnterFrame" => "enterFrame",      
                "LoopComplete" => "loopComplete",    
                "Complete" => "complete",        
                "SegmentStart" => "segmentStart",    
                "Destroy" => "destroy",         
                "ConfigReady" => "config_ready",    
                "DataReady" => "data_ready",      
                "DomLoaded" => "DOMLoaded",  
                "Error" => "error",
                "DataFailed" => "data_failed",     
                "LoadedImages" => "loaded_images",    
                _ => throw new ArgumentOutOfRangeException(nameof(name), name, null)
            };
        }
    }

    #endregion
}