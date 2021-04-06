using Assets.Data;
using Assets.Scripts.Data;
using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class ThemeManager : IThemeManager
    {
        private List<Theme> themes = Static.themes;
        private Theme currentTheme = Static.themes[0];

        private readonly bool debug = false;
        public ThemeManager(bool debug = false)
        {
            this.debug = debug;
        }

        public Theme ReturnCurrentTheme()
        {
            return currentTheme;
        }

        public List<Theme> ReturnThemes()
        {
            // if its in debug include the first testing theme
            return themes;
        }

        public void UpdateCurrentTheme(string name)
        {
            if (name == null)
            {
                Debug.LogError("Theme name is null");
                currentTheme = themes[0];
                return;
            }

            if (debug)
            {
                Debug.Log($"Trying change the theme to {name}");
            }

            currentTheme = themes.Where(i => i.Name == name).FirstOrDefault();

            if (debug)
            {
                Debug.Log($"Current theme is {currentTheme.Name}");
            }
        }
    }
}
