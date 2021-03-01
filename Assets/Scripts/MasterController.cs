using Assets.Data;
using Assets.Scripts.Data;
using Assets.Scripts.Interface;
using Assets.Scripts.Managers;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MasterController : MonoBehaviour
{
    private readonly bool _debug = Static.debug;

    private List<GameObject> ui_elements = new List<GameObject>();

    //UI
    public GameObject ItemDropDown;
    public GameObject MainPanel;

    public GameObject Panel_CreatePrefabList;
    public GameObject Panel_CreatePrefabListElement;

    string currentSelectedList = "";

    public GameObject PrefabPanelActiveList;
    public GameObject PrefabActiveListElement;
    public GameObject PrefabPanelPrefabList;
    public GameObject PrefabPrefabListElement;

    // Managers
    PrefabListManager PrefabListManager = new PrefabListManager(Static.debug);
    ISavingManager savingManager;

    // First thing called after running it 
    public void Awake()
    {
        // Loads data
        LoadData();

        //test();
        // Display Ui
        DisplayUi("PrefabLists");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void test()
    {
        Debug.Log("calling test");
        AddPrefabList("test1");
        AddPrefabList("test2");
        AddPrefabList("test3");
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

        //DeletePrefabList("test1");
        //DeletePrefabList("test2");

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

            // update UI
            DisplayUi("PrefabLists");
        }
    }

    private void DeletePrefabList(string prefabName)
    {
        var success = PrefabListManager.DeletePrefabList(prefabName);

        if (success)
        {
            SaveData();

            // update UI
            DisplayUi("PrefabLists");
        }
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

            if(currentSelectedList == "")
            {
                Debug.LogError("currentlistname is empty");
                return;
            }

            // update UI
            DisplayUi("PrefabListItems", currentSelectedList);
        }
    }

    private void DeleteItemFromPrefabList(string prefabListName, string itemName)
    {
        var success = PrefabListManager.DeleteItemPrefabList(prefabListName, itemName);

        if (success)
        {
            SaveData();
        }
        // update UI
        DisplayUi("PrefabListItems", currentSelectedList);
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

    //Helper methods for ui
    public void DisplayuiPrefabLists()
    {
        DisplayUi("PrefabLists");
    }

    public void DisplayUi(string mode, string name = null)
    {
        Debug.Log($"Displaying '{mode}'");
        // Deletes the current UI if there is one
        DeleteUiElements();

        Panel_CreatePrefabListElement.SetActive(false);

        if (mode == "PrefabLists")
        {
            DisplayUi_PrefabLists();
        }
        else if (mode == "PrefabListItems")
        {
            DisplayUi_PrefabListElements(name);
        }
        else if(mode == "ActiveLists")
        {
            Debug.LogError("function not created yet");
        }
        else if(mode == "ActiveListItems")
        {
            Debug.LogError("function not created yet");
        }
        else
        {
            Debug.LogError($"Invalid mode passed to the DisplayUi '{mode}'");
        }
    }

    private void DisplayUi_PrefabListElements(string prefabListName)
    {
        var items = PrefabListManager.GetPrefabList(prefabListName).GetItems();

        Panel_CreatePrefabListElement.SetActive(true);
        currentSelectedList = prefabListName;

        if (items.Count == 0)
        {
            Debug.Log("No items to show");
            return;
        }

        DeleteUiElements();

        foreach(var item in items)
        {
            GameObject newObj;

            newObj = Instantiate(PrefabPrefabListElement, ItemDropDown.transform);

            // text
            newObj.GetComponentInChildren<TextMeshProUGUI>().text = item.ItemName;

            // delete button
            var button = newObj.GetComponentInChildren<Button>();
            button.onClick.AddListener(() => DeleteItemFromPrefabList(prefabListName, item.ItemName));

            // at the end adds it to the 
            ui_elements.Add(newObj);
        }
    }

    private void DisplayUi_PrefabLists()
    {
        // check if there are any prefabs
        var prefabLists = PrefabListManager.GetPrefabLists();

        if (prefabLists.Count == 0)
        {
            Debug.Log("No prefabLists to display");
            return;
        }

        // Need to delete current Ui 
        DeleteUiElements();

        // generate prefabs
        foreach (var prefab in prefabLists)
        {
            GameObject newObj; // Create GameObject instance

            newObj = Instantiate(PrefabPanelPrefabList, ItemDropDown.transform);

            // Find buttons located on this prefab
            var buttons = newObj.GetComponentsInChildren<Button>();

            // Name button
            buttons[0].GetComponentInChildren<TextMeshProUGUI>().text = prefab.PrefabListName;
            buttons[0].onClick.AddListener(() => DisplayUi("PrefabListItems", prefab.PrefabListName));

            // Start button
            //TODO: Logic for starting the active List

            // Delete button
            buttons[2].onClick.AddListener(() => DeletePrefabList(prefab.PrefabListName));

            // at the end adds it to the 
            ui_elements.Add(newObj);
        }
    }

    public void AddPrefabList(GameObject InputBox)
    {
        var PrefabListName = InputBox.GetComponent<TextMeshProUGUI>().text;

        AddPrefabList(PrefabListName);
    }

    public void ChangePrefabListName(GameObject Text, GameObject InputBox)
    {
        var OldPrefabListName = Text.GetComponent<TextMeshProUGUI>().text;
        var NewPrefabListName = InputBox.GetComponent<TextMeshProUGUI>().text;

        ChangePrefabListName(OldPrefabListName, NewPrefabListName);
    }

    public void AddItemToPrefabList(GameObject InputBox)
    {
        var ItemName = InputBox.GetComponent<TextMeshProUGUI>().text;
        AddItemToPrefabList(currentSelectedList, ItemName);
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
