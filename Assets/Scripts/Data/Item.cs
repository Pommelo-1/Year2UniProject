using System;
using UnityEngine;

namespace Assets.Scripts.Data
{
    /// <summary>
    /// Item is a class which is used to store information about the item
    /// </summary>
    [Serializable]
    public class Item
    {
        // Item Name
        private string itemName;
        public string ItemName 
        { 
            get{ return itemName; }
            set 
            {
                itemName = value;
                ItemLastEdited = DateTime.Now;
            }
        }
        // Item Description
        private string itemDesciption;
        public string ItemDesciption 
        { get { return itemDesciption; }
            set 
            {
                itemDesciption = value;
                ItemLastEdited = DateTime.Now;
            } 
        }
        // Item Ticked
        private bool itemTicked;
        public bool ItemTicked 
        { get { return itemTicked; }
            set 
            {
                itemTicked = value;
                ItemLastEdited = DateTime.Now;
            }
        }
        public DateTime ItemDateCreated { get; }
        public DateTime ItemLastEdited { get; private set; }

        public Item(string itemName, string desciption)
        {
            ItemName = itemName;
            ItemDesciption = desciption;
            ItemTicked = false;
            ItemDateCreated = DateTime.Now;
            ItemLastEdited = ItemDateCreated;
        }
    }
}