using Assets.Scripts.Data;
using System.Collections.Generic;

namespace Assets.Scripts.Interface
{
    public interface IPrefabListManager
    {
        List<PrefabList> GetPrefabLists();
        PrefabList GetPrefabList(string prefabListName);
        void AddPrefabLists(List<PrefabList> prefabLists);
        bool AddPrefabList(PrefabList prefabList);
        void DeletePrefabList(PrefabList prefabList);
        bool DeletePrefabList(string prefabListName);
        void UpdatePrefabList(PrefabList prefabList);
        void AddItemToPrefabList(string prefabListName, string itemName);
    }
}
