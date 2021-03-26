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
        bool AddActiveList(PrefabList activeListName);
        bool DeleteActiveList(string activeListName);
        bool MarkItemasCompleted(string list, string itemName);
        bool UnMarkItemAsUncompleted(string list, string itemName);

    }


}