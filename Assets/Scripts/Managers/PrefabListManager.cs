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
                return false;
            }

            if(_debug)
            {
                Debug.Log($"Deleting prefabList called '{prefabListName}'");
            }

            _prefabLists.Remove(prefabList);
            return true;
        }

        public bool ChangePrefabListName(string currentName, string newName)
        {
            var prefabList = _prefabLists.Find(s => s.PrefabListName == currentName);

            if (prefabList == null)
            {
                return false;
            }

            _prefabLists.Remove(prefabList);

            prefabList.PrefabListName = newName;

            _prefabLists.Add(prefabList);

            return true;
        }

        public bool ChangeItemNameInPrefabList(string prefabListName, string currentName, string newName)
        {
            var prefabList = _prefabLists.Find(s => s.PrefabListName == prefabListName);

            if (prefabList == null)
            {
                return false;
            }

            return _prefabLists.Find(s => s.PrefabListName == prefabListName).ChangeItemName(currentName, newName);
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