using Assets.Data;
using System;
using System.Collections.Generic;

/*
- all the lists they have made
- prefab lists they have made
- items in lists
- settings they changed?
*/

namespace Assets.Data

{
    [Serializable]
    public class SavedData
    {
        public List<ActiveList> activeLists;
        public List<PrefabList> prefabLists;

        public SavedData(List<UserList> activeLists, List<PrefabList> prefabLists)
        {
            this.userLists = activeLists;
            this.prefabLists = prefabLists;
        }
    }
}