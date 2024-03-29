﻿using Assets.Scripts;
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

    public GameObject PrefabConfirmDelete;

    // Managers
    PrefabListManager PrefabListManager = new PrefabListManager(Static.debug);
    ActiveListManager ActiveListManager = new ActiveListManager(Static.debug);
    BinManager BinManager = new BinManager(Static.debug);

    ISavingManager savingManager;
    public TMP_Dropdown themeDropdown;

    UI_Element_Holder ui_Element_Holder;
    ThemeManager themeManager = new ThemeManager(Static.debug);

    //Colors
    public Color Green;
    public Color Red;

    // First thing called after running it
    public void Awake()
    {
        // Loads data
        LoadData();

        test();

        //test();
        // Display Ui
        DisplayUi("PrefabLists");
    }

    public void test()
    {

        var PrefabList = new PrefabList("Traveling Abroad");
        PrefabList.AddItem("passport");
        PrefabList.AddItem("backpack");


        foreach (var item in PrefabList.GetItems())
        {
            Debug.Log($"Inside the {PrefabList.PrefabListName} there is: {item.ItemName}");
        }



        //Debug.Log("calling test");
        //AddPrefabList("test1");
        //AddPrefabList("test2");
        //AddPrefabList("test3");
        //AddItemToPrefabList("test1", "mobile phone");
        //AddItemToPrefabList("test1", "bike");


        //Debug.Log("current items in test1 are");
        //var testItems = PrefabListManager.GetPrefabList("test1").GetItems();
        //foreach (var t in testItems)
        //{
        //    Debug.Log(t.ItemName);
        //}

        //// Change name
        //ChangePrefabListName("test1", "test2");
        //var testPerfab = PrefabListManager.GetPrefabList("test2");

        ////DeletePrefabList("test1");
        ////DeletePrefabList("test2");

        //AddPrefabList("test3");

        //AddItemToPrefabList("test3", "item4");
        //ChangeItemNameInPrefabList("test3", "item4", "item5");

        //DeleteItemFromPrefabListConfirm("test3", "item5");
    }

    // Start is called before the first frame update
    void Start()
    {
        // Makes connection to the other script responsible for applying theme
        ui_Element_Holder = GameObject.Find("Holder").GetComponent<UI_Element_Holder>();

        // Applies theme to all of the elements on the screen
        ui_Element_Holder.SetColours(themeManager.ReturnCurrentTheme());

        // adds the themes to the dropdown
        InstantiateThemeChooser();
    }
    public void OnDropdownThemeChange()
    {
        var menuIndex = themeDropdown.value;
        var menuOptions = themeDropdown.options;
        string dropdownThemeName = menuOptions[menuIndex].text;
        if (_debug)
        {
            Debug.Log($"value in dropdown theme changed to {dropdownThemeName}");
        }

        themeManager.UpdateCurrentTheme(dropdownThemeName);

        // Applies the new theme
        ui_Element_Holder.SetColours(themeManager.ReturnCurrentTheme());
        DisplayUi_PrefabLists();

        SaveData();
    }

    private void InstantiateThemeChooser()
    {
        List<string> themeNames = new List<string>();
        foreach (Theme theme in themeManager.ReturnThemes())
        {
            themeNames.Add(theme.Name);
        }

        // Clears options for dropdown and then add mine
        themeDropdown.ClearOptions();

        themeDropdown.AddOptions(themeNames);
    }
    public void test_2()
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

        DeleteItemFromPrefabListConfirm("test3", "item5");
    }

    // Save Manager
    private void LoadData()
    {
        //TODO: need to implement loading data here
        //var LoadData = savingManager.LoadData("");
    }

    private void SaveData()
    {
        //savingManager.SaveData(new SavedData(), "");
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

    private void DeletePrefabListConfirm(string prefabName)
    {
        Debug.Log($"trying to delete prefab '{prefabName}'");

        // Create GameObject instance
        GameObject newObj;
        newObj = Instantiate(PrefabConfirmDelete, MainPanel.transform);

        // set up text
        var labels = newObj.GetComponentsInChildren<TextMeshProUGUI>();
        var label_name = labels[1];

        label_name.text = prefabName;

        Button button_yes = newObj.GetComponent<Transform>().Find("Panel").Find("Yes").GetComponent<Button>();
        Button button_no = newObj.GetComponent<Transform>().Find("Panel").Find("No").GetComponent<Button>();

        button_yes.onClick.AddListener(() => DeletePrefabList(newObj, prefabName));
        button_no.onClick.AddListener(() => DeleteItSelf(newObj));
    }

    private void DeletePrefabList(GameObject gameObject, string prefabName)
    {
        var prefabList = PrefabListManager.GetPrefabList(prefabName);
        BinManager.AddPrefabList(prefabList);
        BinManager.DisplayPrefabListBin();
        var success = PrefabListManager.DeletePrefabList(prefabName);

        if (success)
        {
            SaveData();
        }

        // update UI
        DisplayUi("PrefabLists");
        DeleteItSelf(gameObject);

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

            if (currentSelectedList == "")
            {
                Debug.LogError("currentlistname is empty");
                return;
            }

            // update UI
            DisplayUi("PrefabListItems", currentSelectedList);
        }
    }

    private void DeleteItemFromPrefabListConfirm(string prefabListName, string itemName)
    {
        Debug.Log($"trying to delete prefab '{itemName}'");

        // Create GameObject instance
        GameObject newObj;
        newObj = Instantiate(PrefabConfirmDelete, MainPanel.transform);

        // set up text
        var labels = newObj.GetComponentsInChildren<TextMeshProUGUI>();
        var label_name = labels[1];

        label_name.text = itemName;

        Button button_yes = newObj.GetComponent<Transform>().Find("Panel").Find("Yes").GetComponent<Button>();
        Button button_no = newObj.GetComponent<Transform>().Find("Panel").Find("No").GetComponent<Button>();

        button_yes.onClick.AddListener(() => DeleteItemFromPrefabList(newObj, prefabListName, itemName));
        button_no.onClick.AddListener(() => DeleteItSelf(newObj));
    }

    private void DeleteItemFromPrefabList(GameObject gameObject, string prefabListName, string itemName)
    {
        var success = PrefabListManager.DeleteItemPrefabList(prefabListName, itemName);

        if (success)
        {
            SaveData();
        }

        // update UI
        DisplayUi("PrefabListItems", currentSelectedList);
        DeleteItSelf(gameObject);
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
        else if (mode == "ActiveLists")
        {
            Display_ActiveLists();
        }
        else if (mode == "ActiveListItems")
        {
            Display_Ui_ActiveList_Elements(name);
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

        foreach (var item in items)
        {
            GameObject newObj;

            newObj = Instantiate(PrefabPrefabListElement, ItemDropDown.transform);

            // text
            newObj.GetComponentInChildren<TextMeshProUGUI>().text = item.ItemName;

            // delete button
            var button = newObj.GetComponentInChildren<Button>();
            button.onClick.AddListener(() => DeleteItemFromPrefabListConfirm(prefabListName, item.ItemName));

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
            buttons[2].onClick.AddListener(() => AddActiveList(prefab.PrefabListName));
            buttons[2].onClick.AddListener(() => DisplayUi("ActiveLists"));

            // Delete button
            buttons[1].onClick.AddListener(() => DeletePrefabListConfirm(prefab.PrefabListName));

            var text = newObj.GetComponentsInChildren<TextMeshProUGUI>()[3].text = prefab.PrefabListDescription;

            // at the end adds it to the
            ui_elements.Add(newObj);
        }
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

    //Active List Code
    public void DisplayuiActiveLists()
    {
        DisplayUi("ActiveLists");
    }

    private void DeleteActiveList(string prefabName)
    {
        var success = ActiveListManager.DeleteActiveList(prefabName);

        if (success)
        {
            SaveData();

            DisplayUi("ActiveLists");
        }
    }

    //Displays all the ActiveLists
    private void Display_ActiveLists()
    {
        // check if there are any prefabs
        var activeLists = ActiveListManager.GetActiveLists();

        if (activeLists.Count == 0)
        {
            Debug.Log("No activeLists to display");
            return;
        }

        // Need to delete current Ui
        DeleteUiElements();

        // generate prefabs
        foreach (var prefab in activeLists)
        {
            GameObject newObj; // Create GameObject instance

            newObj = Instantiate(PrefabPanelActiveList, ItemDropDown.transform);

            // Find buttons located on this prefab
            var buttons = newObj.GetComponentsInChildren<Button>();

            // Delete button, View active list items
            buttons[0].onClick.AddListener(() => DeleteActiveList(prefab.PrefabListName));
            buttons[1].GetComponentInChildren<TextMeshProUGUI>().text = prefab.PrefabListName;
            buttons[1].onClick.AddListener(() => Display_Ui_ActiveList_Elements(prefab.PrefabListName));

            // at the end adds it to the
            ui_elements.Add(newObj);
        }
    }

    //Adds an ActiveList
    public void AddActiveList(string prefabListName)
    {
        var prefabList = PrefabListManager.GetPrefabList(prefabListName);

        var success = ActiveListManager.AddActiveList(prefabList);

        if (success)
        {
            SaveData();

            // update UI
            DisplayUi("ActiveLists");
        }
    }


    //Displays all the items within a ActiveList
    private void Display_Ui_ActiveList_Elements(string activeListName)
    {
        var items = ActiveListManager.GetActiveList(activeListName).GetItems();
        currentSelectedList = activeListName;

        if (items.Count == 0)
        {
            Debug.Log("No items to show");
            return;
        }
        DeleteUiElements();

        foreach (var item in items)
        {
            GameObject newObj;

            newObj = Instantiate(PrefabActiveListElement, ItemDropDown.transform);
            // text
            newObj.GetComponentInChildren<TextMeshProUGUI>().text = item.ItemName;

            // delete button
            var button = newObj.GetComponentInChildren<Button>();
            var image = newObj.GetComponentInChildren<Image>();
            var buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            var isCompleted = item.ItemTicked;

            if (!isCompleted)
            {
                button.onClick.AddListener(() => MarkItemAsCompleted(activeListName, item.ItemName));
                image.color = Red;
                buttonText.text = "Set as completed";
            }
            else
            {
                button.onClick.AddListener(() => UnMarkItemAsUncompleted(activeListName, item.ItemName));
                image.color = Green;
                buttonText.text = "Set as uncompleted";
            }
            // at the end adds it to the
            ui_elements.Add(newObj);
        }
    }

    public void MarkItemAsCompleted(string ActiveListName, string ActiveListItemName)
    {
        var succeded = ActiveListManager.MarkItemasCompleted(ActiveListName, ActiveListItemName);

        if (succeded)
        {
            DisplayUi("ActiveListItems", ActiveListName);
        }
    }

    // TODO: make the same for unmark it
    public void UnMarkItemAsUncompleted(string ActiveListName, string ActiveListItemName)
    {
        var succeeded = ActiveListManager.UnMarkItemAsUncompleted(ActiveListName, ActiveListItemName);
        if (succeeded)
        {
            DisplayUi("ActiveListItems", ActiveListName);
        }
    }

    private void AddDescriptionToTheList(string PrefabLists, string Description)
    {
        var success = PrefabListManager.AddDescription(PrefabLists, Description);

        if(success)
        {
            DisplayUi("PrefabLists");
        }
    }

    public void AddPrefabList(/*GameObject gameObject*/)
    {
        var PrefabListName = GameObject.FindGameObjectWithTag("input_1").GetComponent<TextMeshProUGUI>().text;

        var Description = GameObject.FindGameObjectWithTag("input_2").GetComponent<TextMeshProUGUI>().text;

        // creates a prefab
        AddPrefabList(PrefabListName);

        // adds the description to the prefab
        AddDescriptionToTheList(PrefabListName, Description);
    }
}
