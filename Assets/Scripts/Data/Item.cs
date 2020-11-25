using System;
using UnityEngine;

namespace Assets.Scripts.Data
{
    /// <summary>
    /// Item is a class which is used to store information about the item
    /// </summary>
    public class Item
    {
        public string ItemName { get; set; }
        public string Desciption { get; set; }
        public bool Ticked { get; set; }
        public DateTime DateCreated { get; }

        public Item(string itemName, string desciption = "")
        {
            ItemName = itemName;
            Desciption = desciption;
            Ticked = false;
            DateCreated = DateTime.Now;
        }

        //// ItemName
        ////public void SetItemName(string newItemName)
        ////{
        ////    if(newItemName != "")
        ////    {
        ////        ItemName = newItemName;
        ////    }
        ////    else
        ////    {
        ////        Debug.LogWarning("Trying to set up the name to nothing");
        ////    }
        ////}
        ////public string GetItemName()
        ////{
        ////    return ItemName;
        ////}

        //// Desciption
        //public void SetDesciption(string newDesciption)
        //{
        //    Desciption = newDesciption;
        //}
        //public string GetDescription()
        //{
        //    return Desciption;
        //}

        //// DateCreated
        //public DateTime getDateCreated()
        //{
        //    return DateCreated;
        //}

        //public bool IsTicked()
        //{
        //    return Ticked;
        //}

        //public void SetTickedTrue()
        //{
        //    Ticked = true;
        //}
        //public void SetTickedFalse()
        //{
        //    Ticked = false;
        //}


    }
}