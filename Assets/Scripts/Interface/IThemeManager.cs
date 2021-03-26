using Assets.Data;
using Assets.Scripts.Data;
using System.Collections.Generic;

namespace Assets.Scripts.Interfaces
{
    public interface IThemeManager
    {
        List<Theme> ReturnThemes();
        Theme ReturnCurrentTheme();
        void UpdateCurrentTheme(string themeName);

    }
}
