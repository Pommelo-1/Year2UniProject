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
        public string ItemName { get; set; }
        public string ItemDesciption { get; set; }
        public bool ItemTicked { get; set; }
        public DateTime ItemDateCreated { get; }

        public Item(string itemName, string desciption)
        {
            ItemName = itemName;
            ItemDesciption = desciption;
            ItemTicked = false;
            ItemDateCreated = DateTime.Now;
        }
    }
}