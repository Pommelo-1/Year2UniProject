using Assets.Scripts.Data;
using System.Collections.Generic;

namespace Assets.Scripts.Interface
{
    public interface IPrefabList
    {
        List<Item> GetItems();
        Item GetItem(string itemName);
        void AddItem(string itemName, string itemDescription);
        void AddItems(List<Item> items);
        void DeleteItems();
        void DeleteItem(string itemName);
        void MarkItemTicked(string itemName);
        void MarkItemUnticked(string itemName);
    }
}
