using Assets.Scripts.Data;
using Assets.Scripts.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Assets.Scripts.Managers
{

    public class ActiveListManager : IActiveListManager
    {
        private List<PrefabList> _activeLists = new List<PrefabList>();
        private readonly bool _debug = false;

        public ActiveListManager(bool debug = false)
        {
            _debug = debug;
        }


        public bool AddActiveList(string activeListName)
        {
            if (activeListName.Length == 1)
            {
                SSTools.ShowMessage(msg: "ActiveList empty name empty",
                    position: SSTools.Position.bottom,
                    time: SSTools.Time.threeSecond);

                return false;
            }

            var item = _activeLists.Find(n => n.PrefabListName == activeListName);
            if (item != null)
            {
                if (_debug)
                {
                    Debug.Log($"trying to add item that already exists'{activeListName}'");
                }

                SSTools.ShowMessage(msg: "name already exists",
                    position: SSTools.Position.bottom,
                    time: SSTools.Time.threeSecond);

                return false;
            }

            var activeList = new PrefabList(activeListName, _debug);
            _activeLists.Add(activeList);
            return true;
        }



        public void AddActiveLists(List<PrefabList> activeLists)
        {
            _activeLists = activeLists;
        }

        public bool AddItemToActiveList(string activeListName, string itemName)
        {
            return _activeLists.Find(s => s.PrefabListName == activeListName).AddItem(itemName);
        }

        public bool ChangeActiveListName(string currentName, string newName)
        {
            var activeList = _activeLists.Find(s => s.PrefabListName == currentName);

            if (activeList == null)
            {
                return false;
            }

            _activeLists.Remove(activeList);

            activeList.PrefabListName = newName;

            _activeLists.Add(activeList);

            return true;
        }

        public bool DeleteActiveList(string activeListName)
        {
            var activeList = _activeLists.Find(s => s.PrefabListName == activeListName);

            if (activeList == null)
            {
                return false;
            }

            if (_debug)
            {
                Debug.Log($"Deleting activelist called '{activeListName}'");
            }

            _activeLists.Remove(activeList);
            return true;
        }

        public bool DeleteItemActiveList(string activeListName, string itemName)
        {
            var activeList = _activeLists.Find(s => s.PrefabListName == activeListName);

            if (activeList == null)
            {
                return false;
            }

            return _activeLists.Find(s => s.PrefabListName == activeListName).DeleteItem(itemName);
        }


        public PrefabList GetActiveList(string activeListName)
        {
            if (_debug)
            {
                Debug.Log($"Getting active List called '{activeListName}'");
            }
            return _activeLists.Find(s => s.PrefabListName == activeListName);
        }

        public List<PrefabList> GetActiveLists()
        {
            return _activeLists;
        }

        public bool MarkItemasComplete(string itemName)
        {
            throw new System.NotImplementedException();
        }

        public bool UnMarkItemAsUncompleted(string itemName)
        {
            throw new System.NotImplementedException();
        }
    }
}


