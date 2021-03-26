using Assets.Data;
using Assets.Scripts.Data;
using System;
using System.Collections.Generic;


namespace Assets.Data
{
    [Serializable]
    public class SavedData
    {
        public List<PrefabList> activeLists;
        public List<PrefabList> prefabLists;
        public string ThemeName;

        public SavedData(List<PrefabList> activeLists = null, List<PrefabList> prefabLists = null, string ThemeName = null)
        {
            this.activeLists = activeLists;
            this.prefabLists = prefabLists;
            this.ThemeName = ThemeName;
        }
    }
}