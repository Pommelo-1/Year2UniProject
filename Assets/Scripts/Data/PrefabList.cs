using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Interface;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public class PrefabList : IPrefabList, ICloneable
    {
        // Prefab List Name
        private string prefabListName;
        public string PrefabListName
        {
            get { return prefabListName; }
            set
            {
                prefabListName = value;
                PrefabListLastEdited = DateTime.Now;
            }
        }
        // Prefab List Description
        private string prefabListDescription;
        public string PrefabListDescription
        {
            get { return prefabListDescription; }
            set
            {
                prefabListDescription = value;
                PrefabListLastEdited = DateTime.Now;
            }
        }
        // List of Items
        private List<Item> Items = new List<Item>();
        //Dates
        public DateTime PrefabListDateCreated { get; }
        public DateTime PrefabListLastEdited { get; private set; }

        private readonly bool debug = false;

        public PrefabList(string prefabListName, bool _debug = false)
        {
            debug = _debug;
            PrefabListName = prefabListName;
            PrefabListDateCreated = DateTime.Now;
            PrefabListLastEdited = PrefabListDateCreated;
        }
        #region ICloneable Members

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
        /// <summary>
        /// Used to get all the list of items from the Prefab
        /// </summary>
        /// <returns></returns>
        public List<Item> GetItems()
        {
            return Items;
        }

        /// <summary>
        /// Used to get item from the PrefabList based on the name
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public Item GetItem(string itemName)
        {
            if (debug)
            {
                Debug.Log($"Getting item called {itemName}");
            }
            return Items.Single(r => r.ItemName == itemName);
        }

        /// <summary>
        /// Used to add the Item to the prefabList
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="itemDescription"></param>
        /// <returns></returns>
        public bool AddItem(string itemName, string itemDescription = null)
        {
            // Check if the name is not too short
            if (itemName == null || itemName.Length == 1)
            {
                if (debug)
                {
                    Debug.LogWarning("item name cannot be empty");
                }

                SSTools.ShowMessage(msg: "Habit name empty",
                    position: SSTools.Position.bottom,
                    time: SSTools.Time.threeSecond);

                return false;
            }

            // If the name is not empty it will try create an item
            var item = Items.Find(n => n.ItemName == itemName);
            if (item != null)
            {
                if (debug)
                {
                    Debug.LogWarning("Item already exists");
                }

                SSTools.ShowMessage(msg: "Item already exists",
                    position: SSTools.Position.bottom,
                    time: SSTools.Time.threeSecond);

                return false;
            }

            if (debug)
            {
                Debug.Log($"Adding item called '{itemName}' to the list '{PrefabListName}'.");
            }

            Items.Add(new Item(itemName, itemDescription));
            PrefabListLastEdited = DateTime.Now;

            return true;
        }

        public bool ChangeItemName(string currentName, string newName)
        {
            var item = Items.Find(n => n.ItemName == currentName);
            if (item != null)
            {
                var description = item.ItemDesciption;
                Items.Remove(item);
                Items.Add(new Item(newName, description));
                return true;
            }

            return false;
        }

        /// <summary>
        /// Used to add a list of items to prefab list
        /// </summary>
        /// <param name="items"></param>
        public void AddItems(List<Item> items)
        {
            Items = items;
        }

        /// <summary>
        /// Deletes all items in the PrefabList
        /// </summary>
        public void DeleteItems()
        {
            PrefabListLastEdited = DateTime.Now;
            Items = new List<Item>();
        }

        /// <summary>
        /// Used to delete one element from the PrefabList
        /// </summary>
        /// <param name="item"></param>
        public bool DeleteItem(string itemName)
        {
            var temp_item = Items.Single(r => r.ItemName == itemName);
            if (temp_item != null)
            {
                PrefabListLastEdited = DateTime.Now;
                Items.Remove(temp_item);
                return true;
            }

            Debug.LogWarning("Trying to delete itemt that doesn't exist");
            return false;
        }

        /// <summary>
        /// Marks the Item as ticked
        /// </summary>
        /// <param name="itemName"></param>
        public void MarkItemTicked(string itemName)
        {
            PrefabListLastEdited = DateTime.Now;
            Items.Single(r => r.ItemName == itemName).ItemTicked = true;
        }

        /// <summary>
        /// Marks the item as unticked
        /// </summary>
        /// <param name="itemName"></param>
        public void MarkItemUnticked(string itemName)
        {
            PrefabListLastEdited = DateTime.Now;
            Items.Single(r => r.ItemName == itemName).ItemTicked = false;
        }
    }
}
