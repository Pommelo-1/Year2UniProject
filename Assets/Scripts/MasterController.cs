using Assets.Data;
using Assets.Scripts.Data;
using Assets.Scripts.Interface;
using Assets.Scripts.Managers;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    private readonly bool _debug = Static.debug;

    private List<GameObject> ui_elements = new List<GameObject>();


    public GameObject HabitDropDown;
    public GameObject MainPanel;


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

        // Change name
        ChangePrefabListName("test1", "test2");
        var testPerfab = PrefabListManager.GetPrefabList("test2");

        DeletePrefabList("test1");
        DeletePrefabList("test2");

        AddPrefabList("test3");

        AddItemToPrefabList("test3", "item4");
        ChangeItemNameInPrefabList("test3", "item4", "item5");

        DeleteItemFromPrefabList("test3", "item5");
    }

    // Save Manager
    private void LoadData()
    {
        //TODO: need to implement loading data here
        var LoadData = savingManager.LoadData("");
    }

    private void SaveData()
    {
        savingManager.SaveData(new SavedData(), "");
    }

    public void DeleteData()
    {
        savingManager.DeleteData("");
    }

    // PrefabList
    private void AddPrefabList(string prefabName)
    {
        var success = PrefabListManager.AddPrefabList(prefabName);

        if (success)
        {
            SaveData();
        }

        // TODO: Need to update UI
    }

    private void DeletePrefabList(string prefabName)
    {
        var success = PrefabListManager.DeletePrefabList(prefabName);

        if (success)
        {
            SaveData();
        }

        // TODO: Need to update UI

    }

    private void ChangePrefabListName(string currentName, string newName)
    {
        var success = PrefabListManager.ChangePrefabListName(currentName, newName);

        if (success)
        {
            SaveData();
        }

        // TODO: Need to update UI

    }

    private void AddItemToPrefabList(string prefabListName, string itemName)
    {
        var success = PrefabListManager.AddItemToPrefabList(prefabListName, itemName);

        if (success)
        {
            SaveData();
        }

        // TODO: Need to update UI
    }

    private void DeleteItemFromPrefabList(string prefabListName, string itemName)
    {
        var success = PrefabListManager.DeleteItemPrefabList(prefabListName, itemName);

        if (success)
        {
            SaveData();
        }

        // TODO: Need to update UI
    }

    private void ChangeItemNameInPrefabList(string prefabListName, string currentName, string newName)
    {
        var success = PrefabListManager.ChangeItemNameInPrefabList(prefabListName, currentName, newName);

        if (success)
        {
            SaveData();
        }

        // TODO: Need to update UI
    }

    // UI
    public void DeleteUiElements()
    {
        ui_elements.ForEach(child => Destroy(child));
    }

    public void ClearTextFromInputBox(GameObject gameObject)
    {
        gameObject.GetComponent<TMP_InputField>().text = "";
    }

    public void DisplayUi(string mode)
    {
        // Deletes the current UI if there is one
        DeleteUiElements();

        // TODO:
    }

    public void AddPrefabList(GameObject InputBox)
    {
        var PrefabListName = InputBox.GetComponent<TextMeshProUGUI>().text;

        AddPrefabList(PrefabListName);
    }

    public void DeletePrefabList(GameObject InputBox)
    {
        var PrefabListName = InputBox.GetComponent<TextMeshProUGUI>().text;

        DeletePrefabList(PrefabListName);
    }

    public void ChangePrefabListName(GameObject Text, GameObject InputBox)
    {

        var OldPrefabListName = Text.GetComponent<TextMeshProUGUI>().text;
        var NewPrefabListName = InputBox.GetComponent<TextMeshProUGUI>().text;

        ChangePrefabListName(OldPrefabListName, NewPrefabListName);
    }

    public void AddItemToPrefabList(GameObject Text, GameObject InputBox)
    {
        var PrefabListName = Text.GetComponent<TextMeshProUGUI>().text;
        var ItemName = InputBox.GetComponent<TextMeshProUGUI>().text;

        AddItemToPrefabList(PrefabListName, ItemName);
    }

    public void DeleteItemFromPrefabList(GameObject Text, GameObject Text2)
    {
        var PrefabListName = Text.GetComponent<TextMeshProUGUI>().text;
        var ItemName = Text2.GetComponent<TextMeshProUGUI>().text;

        DeleteItemFromPrefabList(PrefabListName, ItemName);
    }

    public void ChangeItemNameInPrefabList(GameObject Text, GameObject Text2, GameObject InputBox)
    {
        var PrefabListName = Text.GetComponent<TextMeshProUGUI>().text;
        var OldItemName = Text2.GetComponent<TextMeshProUGUI>().text;
        var NewItemName = InputBox.GetComponent<TextMeshProUGUI>().text;

        ChangeItemNameInPrefabList(PrefabListName, OldItemName, NewItemName);
    }

    public void GeneratePrefabLists()
    {

    }

    public void GeneretePrefabList()
    {

    }



    private void DeleteItSelf(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    public void OpenPrivacyPolicyWebpage()
    {
        Application.OpenURL("https://sites.google.com/view/mgameskprivacypolicy/home?authuser=2");
    }
}
