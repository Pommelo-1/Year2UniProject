using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public static class Static
    {
        // TODO: Change to to false in production enviropment
        public static bool debug = true;

        // Colours
        private static readonly Theme theme_0 = new Theme("testing_1",
            new Color32(0, 0, 0, 0),
            new Color32(0, 0, 0, 0),
            new Color32(0, 0, 0, 0),
            new Color32(0, 0, 0, 0),
            new Color32(0, 0, 0, 0));

        // Used https://coolors.co/1282a2-ddf8e8-f06449-ff5d73-1b2021
        private static Color32 EerieBlack = new Color32(27, 32, 33, 255);
        private static Color32 FieryRose = new Color32(255, 93, 115, 255);
        private static Color32 OrangeSoda = new Color32(240, 100, 73, 255);
        private static Color32 Honeydew = new Color32(221, 248, 232, 255);
        private static Color32 CGBlue = new Color32(18, 130, 162, 255);

        private static Color32 Snow = new Color32(251, 245, 243, 255);
        private static Color32 CeladonGreen = new Color32(54, 130, 127, 255);
        private static Color32 Crimson = new Color32(214, 40, 57, 255);
        private static Color32 CornflowerBlue = new Color32(131, 144, 250, 255);

        private static Color32 Silver = new Color32(214, 40, 57, 255);
        private static Color32 SpanishGray = new Color32(153, 153, 153, 255);
        private static Color32 Onyx = new Color32(61, 61, 61, 255);
        private static Color32 Cultured = new Color32(239, 239, 239, 255);

        private static Color32 Cinereous = new Color32(147, 130, 123, 255);
        private static Color32 CadetBlue = new Color32(86, 163, 166, 255);
        private static Color32 YellowCrayola = new Color32(255, 232, 130, 255);
        private static Color32 WildBlueYonder = new Color32(173, 178, 211, 255);

        private static Color32 RussianViolet = new Color32(50, 14, 59, 255);
        private static Color32 SpanishViolet = new Color32(76, 42, 133, 255);
        private static Color32 Glaucous = new Color32(107, 127, 215, 255);
        private static Color32 BlizzardBlue = new Color32(173, 178, 211, 255);
        private static Color32 Nyanza = new Color32(221, 251, 210, 255);


        private static readonly Theme theme_1 = new Theme("Basic", EerieBlack, FieryRose, OrangeSoda, Honeydew, CGBlue);
        private static readonly Theme theme_2 = new Theme("Contrast", EerieBlack, Snow, CeladonGreen, Crimson, CornflowerBlue);
        private static readonly Theme theme_3 = new Theme("Greys", EerieBlack, Silver, SpanishGray, Onyx, Cultured);
        private static readonly Theme theme_4 = new Theme("Funky", EerieBlack, Cinereous, CadetBlue, YellowCrayola, WildBlueYonder);
        private static readonly Theme theme_5 = new Theme("Night", RussianViolet, SpanishViolet, Glaucous, BlizzardBlue, Nyanza);


        public static List<Theme> themes = new List<Theme> { theme_0, theme_1, theme_2, theme_3, theme_4, theme_5};

    }
}
