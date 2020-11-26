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
        public string ItemName 
        { 
            get{ return ItemName; }
            set 
            {
                ItemName = value;
                ItemLastEdited = DateTime.Now;
            }
        }
        public string ItemDesciption 
        { get { return ItemDesciption; }
            set 
            {
                ItemDesciption = value;
                ItemLastEdited = DateTime.Now;
            } 
        }
        public bool ItemTicked 
        { get { return ItemTicked; }
            set 
            {
                ItemTicked = value;
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