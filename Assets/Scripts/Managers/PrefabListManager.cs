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
            var currentItems = _prefabLists.Find(s => s.PrefabListName == prefabListName).GetItems();

            var item = currentItems.Find(n => n.ItemName == prefabListName);
            if (item != null)
            {
                if (_debug)
                {
                    Debug.Log($"trying to add item that already exisits '{prefabListName}'");
                }
                return false;
            }

            _prefabLists.Find(s => s.PrefabListName == prefabListName).AddItem(itemName);
            return true;
        }

        public bool AddPrefabList(PrefabList prefabList)
        {
            var item = _prefabLists.Find(n => n == prefabList);

            if (item != null)
            {
                if (_debug)
                {
                    Debug.Log($"trying to add item that already exisits '{prefabList.PrefabListName}'");
                }

                SSTools.ShowMessage(msg: "name already exists",
                    position: SSTools.Position.bottom,
                    time: SSTools.Time.threeSecond);

                return false;
            }

            _prefabLists.Add(prefabList);
            return true;
        }

        public void DeletePrefabList(PrefabList prefabList)
        {
            _prefabLists.Remove(prefabList);
        }

        public bool DeletePrefabList(string prefabListName)
        {
            var prefabList = _prefabLists.Find(s => s.PrefabListName == prefabListName);

            if (prefabList == null)
            {
                return false;
            }

            _prefabLists.Remove(prefabList);
            return true;
        }

        public void UpdatePrefabList(PrefabList prefabList)
        {

        }

    }
}