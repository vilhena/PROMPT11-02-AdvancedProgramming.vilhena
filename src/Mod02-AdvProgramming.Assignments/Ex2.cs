namespace Mod02_AdvProgramming.Assignments
{
    using System;
    public static class Ex2
    {
        public class Fan {
            public string Label  { get; set; }
            public string Slogan { get; set; }
        }

        public static Func<Fan>[] GenerateFans(string[] clubs)
        {
            if (clubs == null) return null;
            
            var fans = new Func<Fan>[clubs.Length];
            int idx = 0;
            
                foreach (string club in clubs)
                {
                    string label = "Fan of club \"" + club;
                    string clubLocal = club;
                    fans[idx++] = () => new Fan {Label = label, Slogan = clubLocal.ToUpper() + "!!!"};
                }
            
            return fans;
        }
    }
}