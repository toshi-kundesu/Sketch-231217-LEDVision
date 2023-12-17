using System.Collections.Generic;
using UnityEngine;


public static class Utility
{
    public struct ColorInfo
    {
        public UnityEngine.Color Color { get; private set; }
        public int FilterNumber { get; private set; }

        public ColorInfo(UnityEngine.Color color, int filterNumber)
        {
            Color = color;
            FilterNumber = filterNumber;
        }
    }

    public class ColorGel
    {
        private static readonly Dictionary<string, ColorInfo> colorGelInfo = new Dictionary<string, ColorInfo>
        {
            { "Red", new ColorInfo(new UnityEngine.Color(255f/255f, 0f, 0f), 126) },
            { "Green", new ColorInfo(new UnityEngine.Color(0f, 255f/255f, 0f), 127) },
            { "Blue", new ColorInfo(new UnityEngine.Color(0f, 0f, 255f/255f), 128) },
            { "Yellow", new ColorInfo(new UnityEngine.Color(255f/255f, 255f/255f, 0f), 129) },
            { "Magenta", new ColorInfo(new UnityEngine.Color(255f/255f, 0f, 255f/255f), 130) },
            { "Cyan", new ColorInfo(new UnityEngine.Color(0f, 255f/255f, 255f/255f), 131) },
            { "White", new ColorInfo(new UnityEngine.Color(255f/255f, 255f/255f, 255f/255f), 132) },
            { "Black", new ColorInfo(new UnityEngine.Color(0f, 0f, 0f), 133) },
            { "Orange", new ColorInfo(new UnityEngine.Color(255f/255f, 165f/255f, 0f), 134) },
            { "Purple", new ColorInfo(new UnityEngine.Color(128f/255f, 0f, 128f/255f), 135) },
            { "Pink", new ColorInfo(new UnityEngine.Color(255f/255f, 192f/255f, 203f/255f), 136) },
            { "Brown", new ColorInfo(new UnityEngine.Color(165f/255f, 42f/255f, 42f/255f), 137) },
            { "Gray", new ColorInfo(new UnityEngine.Color(128f/255f, 128f/255f, 128f/255f), 138) },
            { "Lime", new ColorInfo(new UnityEngine.Color(0f, 255f/255f, 0f), 139) },
            { "Maroon", new ColorInfo(new UnityEngine.Color(128f/255f, 0f, 0f), 140) },
            { "Olive", new ColorInfo(new UnityEngine.Color(128f/255f, 128f/255f, 0f), 141) },
            { "Navy", new ColorInfo(new UnityEngine.Color(0f, 0f, 128f/255f), 142) },
            { "Teal", new ColorInfo(new UnityEngine.Color(0f, 128f/255f, 128f/255f), 143) },
            { "Silver", new ColorInfo(new UnityEngine.Color(192f/255f, 192f/255f, 192f/255f), 144) },
            { "Gold", new ColorInfo(new UnityEngine.Color(255f/255f, 215f/255f, 0f), 145) },
            { "Amber", new ColorInfo(new UnityEngine.Color(255f/255f, 191f/255f, 0f), 101) },
            { "Ruby", new ColorInfo(new UnityEngine.Color(206f/255f, 17f/255f, 38f/255f), 102) },
            { "Emerald", new ColorInfo(new UnityEngine.Color(0f, 210f/255f, 190f/255f), 103) },
            { "Sapphire", new ColorInfo(new UnityEngine.Color(15f/255f, 82f/255f, 186f/255f), 104) },
            { "Diamond", new ColorInfo(new UnityEngine.Color(185f/255f, 242f/255f, 255f/255f), 105) },
            { "Opal", new ColorInfo(new UnityEngine.Color(102f/255f, 204f/255f, 204f/255f), 106) },
            { "Topaz", new ColorInfo(new UnityEngine.Color(255f/255f, 200f/255f, 0f), 107) },
            { "Pearl", new ColorInfo(new UnityEngine.Color(253f/255f, 245f/255f, 230f/255f), 108) },
            { "Jade", new ColorInfo(new UnityEngine.Color(0f, 168f/255f, 107f/255f), 109) },
            { "Garnet", new ColorInfo(new UnityEngine.Color(179f/255f, 27f/255f, 27f/255f), 110) },
            { "Onyx", new ColorInfo(new UnityEngine.Color(53f/255f, 56f/255f, 57f/255f), 111) },
            { "Turquoise", new ColorInfo(new UnityEngine.Color(64f/255f, 224f/255f, 208f/255f), 112) },
            { "Quartz", new ColorInfo(new UnityEngine.Color(81f/255f, 72f/255f, 79f/255f), 113) },
            { "Coral", new ColorInfo(new UnityEngine.Color(255f/255f, 127f/255f, 80f/255f), 114) },
            { "Amethyst", new ColorInfo(new UnityEngine.Color(153f/255f, 102f/255f, 204f/255f), 115) },
            { "Aquamarine", new ColorInfo(new UnityEngine.Color(127f/255f, 255f/255f, 212f/255f), 116) },
            { "Beryl", new ColorInfo(new UnityEngine.Color(96f/255f, 192f/255f, 192f/255f), 117) },
            { "Citrine", new ColorInfo(new UnityEngine.Color(228f/255f, 208f/255f, 10f/255f), 118) },
            { "FireOpal", new ColorInfo(new UnityEngine.Color(255f/255f, 101f/255f, 1f/255f), 119) },
            { "Moonstone", new ColorInfo(new UnityEngine.Color(224f/255f, 255f/255f, 255f/255f), 120) },
            { "Sunstone", new ColorInfo(new UnityEngine.Color(255f/255f, 204f/255f, 50f/255f), 121) },
            { "Tanzanite", new ColorInfo(new UnityEngine.Color(116f/255f, 66f/255f, 200f/255f), 122) },
            { "TopazBlue", new ColorInfo(new UnityEngine.Color(0f, 185f/255f, 255f/255f), 123) },
            { "Zircon", new ColorInfo(new UnityEngine.Color(188f/255f, 210f/255f, 238f/255f), 124) },
            { "Tourmaline", new ColorInfo(new UnityEngine.Color(210f/255f, 105f/255f, 30f/255f), 125) },
        };

        public ColorInfo this[string colorName]
        {
            get { return colorGelInfo[colorName]; }
        }
    }
}