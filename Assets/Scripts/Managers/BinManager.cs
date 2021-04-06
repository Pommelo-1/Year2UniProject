using Assets.Scripts.Data;
using Assets.Scripts.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class BinManager : IBinManager
    {
        private readonly bool _debug = false;

        private List<PrefabList> PrefabLists = new List<PrefabList>();
        private List<PrefabList> ActiveLists = new List<PrefabList>();


        public BinManager(bool debug = false)
        {
            _debug = debug;
        }

        public void AddPrefabList(PrefabList prefabList)
        {
            if(prefabList == null)
            {
                return;
            }

            PrefabLists.Add(prefabList);
        }

        public void AddActiveList(PrefabList activeList)
        {
            if (activeList == null)
            {
                return;
            }

            ActiveLists.Add(activeList);
        }

        public void DisplayPrefabListBin()
        {
            Debug.Log("The content of the prefab List bin is: ");
            foreach(var item in PrefabLists)
            {
                Debug.Log(item.PrefabListName);
            }
        }

        public void DisplayActiveListBin()
        {
            Debug.Log("The content of the Active List bin is: ");
            foreach (var item in ActiveLists)
            {
                Debug.Log(item.PrefabListName);
            }
        }
    }
}
