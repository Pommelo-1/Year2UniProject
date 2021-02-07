using Assets.Scripts.Data;
using System.Collections.Generic;

namespace Assets.Scripts.Interface
{
    public interface IPrefabListManager
    {
        List<PrefabList> GetPrefabLists();
        PrefabList GetPrefabList(string prefabListName);
        void AddPrefabLists(List<PrefabList> prefabLists);
        bool AddPrefabList(string prefabListName);
        bool DeletePrefabList(string prefabListName);
        bool ChangePrefabListName(string currentName, string newName);
        bool AddItemToPrefabList(string prefabListName, string itemName);
        bool DeleteItemPrefabList(string prefabListName, string itemName);
    }
}
