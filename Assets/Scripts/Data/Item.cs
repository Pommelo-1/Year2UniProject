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
        public string Desciption { get; set; }
        public bool Ticked { get; set; }
        public DateTime DateCreated { get; }

        public Item(string itemName, string desciption)
        {
            ItemName = itemName;
            Desciption = desciption;
            Ticked = false;
            DateCreated = DateTime.Now;
        }
    }
}