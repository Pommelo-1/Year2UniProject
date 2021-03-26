using Assets.Scripts.Data;
using Assets.Scripts.Interface;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

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


        public bool AddActiveList(PrefabList activeList)
        {
            if (activeList.PrefabListName.Length == 1)
            {
                SSTools.ShowMessage(msg: "ActiveList empty name empty",
                    position: SSTools.Position.bottom,
                    time: SSTools.Time.threeSecond);

                return false;
            }


            var activeListCopy =(PrefabList) activeList.Clone();
            var item = _activeLists.Find(n => n.PrefabListName == activeListCopy.PrefabListName);
            if (item != null)
            {

                int num = UnityEngine.Random.Range(0, 1000);
                activeListCopy.PrefabListName += $"[{num}]";
                _activeLists.Add(activeListCopy);
                return true;
            }

            _activeLists.Add(activeListCopy);
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


        public bool MarkItemasCompleted(string list, string itemName)
        {
            var activeList = _activeLists.Find(s => s.PrefabListName == list);
            activeList.MarkItemTicked(itemName);
            return true;


        }

        public bool UnMarkItemAsUncompleted(string list, string itemName)
        {
            var activeList = _activeLists.Find(s => s.PrefabListName == list);
            activeList.MarkItemUnticked(itemName);
            return true;
        }
    }
}


