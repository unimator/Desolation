using System;
using System.Collections.Generic;

namespace Desolation.Basic.Config.Options
{
    public static class WindowFeatures
    {
        public static List<Tuple<int, int>> Resolution = new List<Tuple<int, int>>()
        {
            new Tuple<int, int>(800, 600),
            new Tuple<int, int>(1024, 768),
            new Tuple<int, int>(1920, 1200)
        };

        public enum BitsPerPixel
        {
            Bpp16,
            Bpp32
        }

        public enum RefreshRate
        {
            Ref30,
            Ref60
        }

        public enum BorderType
        {
            Normal,
            Borderless,
            Fullscreen
        }
    }
}