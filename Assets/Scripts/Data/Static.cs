using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public static class Static
    {
        // TODO: Change to to false in production enviropment
        public static bool debug = true;

        // Colours
        // Used https://coolors.co/1282a2-ddf8e8-f06449-ff5d73-1b2021
        private static Color32 EerieBlack = new Color32(27, 32, 33, 255);
        private static Color32 FieryRose = new Color32(255, 93, 115, 255);
        private static Color32 OrangeSoda = new Color32(240, 100, 73, 255);
        private static Color32 Honeydew = new Color32(221, 248, 232, 255);
        private static Color32 CGBlue = new Color32(18, 130, 162, 255);

        private static readonly Theme theme_1 = new Theme("Basic", EerieBlack, FieryRose, OrangeSoda, Honeydew, CGBlue);

        private static readonly Theme theme_2 = new Theme("testing_1",
            new Color32(0, 0, 0, 0),
            new Color32(0, 0, 0, 0),
            new Color32(0, 0, 0, 0),
            new Color32(0, 0, 0, 0),
            new Color32(0, 0, 0, 0));

        public static List<Theme> themes = new List<Theme> { theme_1, theme_2 };

    }
}
