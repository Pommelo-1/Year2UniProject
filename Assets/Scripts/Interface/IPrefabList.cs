using Assets.Scripts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interface
{
    interface IPrefabList
    {
        List<Item> GetItems();
        Item GetItem(string itemName);
        bool AddItem(string itemName, string itemDescription);
        void AddItems(List<Item> items);
        void DeleteItems();
        void DeleteItem(string itemName);
        void MarkItemTicked(string itemName);
        void MarkItemUnticked(string itemName);
    }
}
