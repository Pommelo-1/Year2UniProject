using Assets.Scripts.Data;
using Assets.Scripts.Interface;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class PrefabListManager : IPrefabListManager
    {
        private List<PrefabList> _prefabLists = new List<PrefabList>();

        private readonly bool _debug = false;

        public PrefabListManager(bool debug = false)
        {
            _debug = debug;
        }

        public List<PrefabList> GetPrefabLists()
        {
            return _prefabLists;
        }

        public PrefabList GetPrefabList(string prefabListName)
        {
            if (_debug)
            {
                Debug.Log($"Getting prefab List called '{prefabListName}'");
            }
            return _prefabLists.Find(s => s.PrefabListName == prefabListName);
        }

        public void AddPrefabLists(List<PrefabList> prefabLists)
        {
            _prefabLists = prefabLists;
        }

        public bool AddItemToPrefabList(string prefabListName, string itemName)
        {
            return _prefabLists.Find(s => s.PrefabListName == prefabListName).AddItem(itemName);
        }

        public bool AddPrefabList(string prefabListName)
        {
            if (prefabListName.Length == 1)
            {
                SSTools.ShowMessage(msg: "PrefabList empty name empty",
                    position: SSTools.Position.bottom,
                    time: SSTools.Time.threeSecond);

                return false;
            }

            var item = _prefabLists.Find(n => n.PrefabListName == prefabListName);
            if (item != null)
            {
                if (_debug)
                {
                    Debug.Log($"trying to add item that already exisits '{prefabListName}'");
                }

                SSTools.ShowMessage(msg: "name already exists",
                    position: SSTools.Position.bottom,
                    time: SSTools.Time.threeSecond);

                return false;
            }

            var prefabList = new PrefabList(prefabListName, _debug);
            _prefabLists.Add(prefabList);
            return true;
        }

        public bool DeletePrefabList(string prefabListName)
        {
            var prefabList = _prefabLists.Find(s => s.PrefabListName == prefabListName);

            if (prefabList == null)
            {
                Debug.LogWarning($"trying to delete the prefabList '{prefabListName}' that does not exists!");
                return false;
            }

            if (_debug)
            {
                Debug.Log($"Deleting prefabList called '{prefabListName}'");
            }

            _prefabLists.Remove(prefabList);

            return true;
        }

        public bool ChangePrefabListName(string currentName, string newName)
        {
            // checks for the new name length
            if (newName.Length == 1)
            {
                SSTools.ShowMessage(msg: "New name cannot be empty",
                    position: SSTools.Position.bottom,
                    time: SSTools.Time.threeSecond);

                return false;
            }

            // look for prefabList
            var prefabList = _prefabLists.Find(s => s.PrefabListName == currentName);

            // check if the prefabList exists
            if (prefabList == null)
            {

                if (_debug)
                {
                    Debug.LogWarning($"Could not find the PrefabList called '{currentName}'");
                }

                SSTools.ShowMessage(msg: "Could not find requested prefabList",
                    position: SSTools.Position.bottom,
                    time: SSTools.Time.threeSecond);
                return false;
            }

            // makes copy of current prefablist
            var copyPrefabList = (PrefabList)prefabList.Clone();

            // removes old prefabList
            _prefabLists.Remove(prefabList);

            // applies new name
            copyPrefabList.PrefabListName = newName;

            // adds it to the list
            _prefabLists.Add(copyPrefabList);

            return true;
        }

        public bool ChangeItemNameInPrefabList(string prefabListName, string currentName, string newName)
        {
            if (newName.Length == 1)
            {
                SSTools.ShowMessage(msg: "New name cannot be empty",
                    position: SSTools.Position.bottom,
                    time: SSTools.Time.threeSecond);

                return false;
            }

            // Finds the prefabList
            var prefabList = _prefabLists.Find(s => s.PrefabListName == prefabListName);

            // checks if the prefab list exists
            if (prefabList == null)
            {
                if (_debug)
                {
                    Debug.LogWarning($"Could not find the PrefabList called '{prefabListName}'");
                }

                SSTools.ShowMessage(msg: "Could not find requested prefabList",
                    position: SSTools.Position.bottom,
                    time: SSTools.Time.threeSecond);

                return false;
            }

            // at the end changes the of the item in the selected prefabList
            var succeded = _prefabLists.Find(s => s.PrefabListName == prefabListName).ChangeItemName(currentName, newName);

            if (succeded)
            {
                return true;
            }

            SSTools.ShowMessage(msg: "There was a problem when changing the name of item",
                position: SSTools.Position.bottom,
                time: SSTools.Time.threeSecond);

            return false;
        }

        public bool DeleteItemPrefabList(string prefabListName, string itemName)
        {
            var prefabList = _prefabLists.Find(s => s.PrefabListName == prefabListName);

            if (prefabList == null)
            {
                return false;
            }

            return _prefabLists.Find(s => s.PrefabListName == prefabListName).DeleteItem(itemName);
        }
    }
}