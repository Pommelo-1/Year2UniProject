using Assets.Scripts.Data;
using Assets.Scripts.Interface;
using Assets.Scripts.Managers;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    private readonly bool _debug = Static.debug;

    // Managers
    PrefabListManager PrefabListManager = new PrefabListManager(Static.debug);
    ISavingManager savingManager;

    // First thing called after running it 
    public void Awake()
    {
        // Loads data
        LoadData();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void test()
    {
        AddPrefabList("test1");
        AddItemToPrefabList("test1", "mobile phone");
        AddItemToPrefabList("test1", "bike");


        Debug.Log("current items in test1 are");
        var testItems = PrefabListManager.GetPrefabList("test1").GetItems();
        foreach (var t in testItems)
        {
            Debug.Log(t.ItemName);
        }
    }

    // Save Manager
    private void LoadData()
    {
        //TODO: need to implement loading data here
        //var SaveData = savingManager.LoadData();
    }

    private void SaveData()
    {

    }

    /// <summary>
    /// Function used to add the prefabList to the PrefabManager by providing the name
    /// </summary>
    public void AddPrefabList(string prefabName)
    {
        bool emptystring = false;

        if (prefabName.Length == 1)
        {
            SSTools.ShowMessage(msg: "PrefabList empty name empty",
                position: SSTools.Position.bottom,
                time: SSTools.Time.threeSecond);

            emptystring = true;
        }
        // TODO: Check if the list already not exisits

        if (!emptystring)
        {
            var prefabList = new PrefabList(prefabName, _debug);
            var success = PrefabListManager.AddPrefabList(prefabList);

            if (success)
            {
                SaveData();
            }
        }
    }

    public void DeletePrefabList(string prefabName)
    {

    }

    public void ChangePrefabListName(string currentName, string newName)
    {

    }

    // PrefabList
    public void AddItemToPrefabList(string prefabListName, string itemName)
    {
        PrefabListManager.AddItemToPrefabList(prefabListName, itemName);
    }

    public void DeleteItemFromPrefabList(string prefabListName, string itemName)
    {

    }

    public void ChangeItemNameInPrefabList(string prefabListName, string currentName, string newName)
    {

    }

}
