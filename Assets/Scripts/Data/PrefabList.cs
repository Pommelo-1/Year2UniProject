using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Interface;
using UnityEngine;

namespace Assets.Scripts.Data
{
    class PrefabList : IPrefabList
    {
        public string PrefabListName
        {
            get { return PrefabListName; }
            set
            {
                PrefabListName = value;
                PrefabListLastEdited = DateTime.Now;
            }
        }
        public string PrefabListDescription
        {
            get { return PrefabListDescription; }
            set
            {
                PrefabListDescription = value;
                PrefabListLastEdited = DateTime.Now;
            }
        }
        private List<Item> Items = new List<Item>();
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
            return Items.Single(r => r.ItemName == itemName);
        }

        /// <summary>
        /// Used to add the Item to the prefabList
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="itemDescription"></param>
        /// <returns></returns>
        public bool AddItem(string itemName, string itemDescription)
        {
            bool exisits = false;
            bool emptystring = false;

            // Check if the name is not too short
            if (itemName.Length == 1)
            {
                if (debug)
                {
                    Debug.LogWarning("Habit name cannot be empty");
                }

                SSTools.ShowMessage(msg: "Habit name empty",
                    position: SSTools.Position.bottom,
                    time: SSTools.Time.threeSecond);
                emptystring = true;
            }

            // If the name is not empty it will try create an item
            if (!emptystring)
            {
                // checks first if the item already 
                foreach (Item item in Items)
                {
                    if (item.ItemName == itemName)
                    {
                        exisits = true;
                        SSTools.ShowMessage(msg: "Item already exists",
                            position: SSTools.Position.bottom,
                            time: SSTools.Time.threeSecond);
                        break;
                    }
                }

                if (!exisits)
                {
                    if (debug)
                    {
                        Debug.Log($"Adding item called '{itemName}' to the list '{PrefabListName}'.");
                    }
                    Item temp_item = new Item(itemName, itemDescription);
                    Items.Add(temp_item);
                    PrefabListLastEdited = DateTime.Now;

                    return true;
                }
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
        public void DeleteItem(string itemName)
        {
            var temp_item = Items.Single(r => r.ItemName == itemName);
            if (temp_item != null)
            {
                PrefabListLastEdited = DateTime.Now;
                Items.Remove(temp_item);
            }
            else
            {
                Debug.LogWarning("Trying to delete itemt that doesn't exist");
            }
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
