using System.Collections;
using Assets.Scripts.Data;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Interface
{
    public interface IActiveListManager
    {
        List<PrefabList> GetActiveLists();
        PrefabList GetActiveList(string activeListName);
        void AddActiveLists(List<PrefabList> activeLists);
        bool AddActiveList(PrefabList activeListName);
        bool DeleteActiveList(string activeListName);
        bool ChangeActiveListName(string currentName, string newName);
        bool AddItemToActiveList(string activeListName, string itemName);
        bool DeleteItemActiveList(string activeListName, string itemName);
        bool MarkItemasCompleted(string list, string itemName);
        bool UnMarkItemAsUncompleted(string list, string itemName);

    }


}