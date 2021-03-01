using Assets.Data;
using Assets.Scripts.Data;
using System;
using System.Collections.Generic;

/*
- all the lists they have made
- prefab lists they have made
- items in lists
*/

namespace Assets.Data

{
    [Serializable]
    public class SavedData
    {
        public List<PrefabList> activeLists;
        public List<PrefabList> prefabLists;

        public SavedData(List<PrefabList> activeLists = null, List<PrefabList> prefabLists = null)
        {
            this.activeLists = activeLists;
            this.prefabLists = prefabLists;
        }
    }
}