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

        //public List<Habit> habits;
        //public string themeName;

        public List<UserList> userLists;
        public List<PrefabList> prefabLists;
        public List<Items> itemsInList;
        //settings

        public SavedData(List<UserList> userLists, List<PrefabList> prefabLists, List<Items> itemsInList)
        {
            this.userLists = userLists;
            this.prefabLists = prefabLists;
            this.itemsInList = itemsInList;
        }
    }
}