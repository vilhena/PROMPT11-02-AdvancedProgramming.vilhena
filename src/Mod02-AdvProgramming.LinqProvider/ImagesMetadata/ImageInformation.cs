using System;

namespace Mod02_AdvProgramming.LinqProvider.ImagesMetadata
{
    public class ImageInformation
    {

        public String Location { get; set; }
        public DateTime DateTaken { get; set; }
        public TimeSpan DaysTaken { get; set; }
        public CameraInformation Camera { get; set; }
    }
}