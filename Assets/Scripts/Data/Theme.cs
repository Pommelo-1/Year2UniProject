using System;
using UnityEngine;

namespace Assets.Scripts.Data
  {
    [Serializable]
    public class Theme
    {
        public string Name { get; }
        public Color32 Color_1 { get; }
        public Color32 Color_2 { get; }
        public Color32 Color_3 { get; }
        public Color32 Color_4 { get; }
        public Color32 Color_5 { get; }

        public Theme(string name, Color32 color_1, Color32 color_2, Color32 color_3, Color32 color_4, Color32 color_5)
        {
            Name = name;
            Color_1 = color_1;
            Color_2 = color_2;
            Color_3 = color_3;
            Color_4 = color_4;
            Color_5 = color_5;
        }
    }
}
