using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Data;

public class Mike_Testing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestingPrefabList();
    }


    void TestingPrefabList()
    {
        PrefabList prefabList1 = new PrefabList("prefab list name 1", true);

        prefabList1.AddItem("Water");
        prefabList1.AddItem("Rock", "It's a rock");
        prefabList1.AddItem(null);

        Debug.Log($"Current item in the {prefabList1.PrefabListName}:");
        foreach (var item in prefabList1.GetItems())
        {
            Debug.Log($"-> {item.ItemName}");
        }

        string itemToFind = "Rock";
        var item2 = prefabList1.GetItem(itemToFind);
        Debug.Log($"Description of item {itemToFind} is {item2.ItemDesciption}");

        prefabList1.DeleteItem(itemToFind);

        PrefabList prefabList2 = new PrefabList("prefab list name 2", true);

        Debug.Log($"Name of prefabList2 before change {prefabList2.PrefabListName}");
        prefabList2.PrefabListName = "New name ";

        Debug.Log($"Name of prefabList2 after change {prefabList2.PrefabListName}");

    }
}
