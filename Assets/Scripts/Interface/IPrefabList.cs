using Assets.Scripts.Data;
using System.Collections.Generic;

namespace Assets.Scripts.Interface
{
    public interface IPrefabList
    {
        List<Item> GetItems();
        Item GetItem(string itemName);
        bool AddItem(string itemName, string itemDescription);
        void AddItems(List<Item> items);
        void DeleteItems();
        bool DeleteItem(string itemName);
        void MarkItemTicked(string itemName);
        void MarkItemUnticked(string itemName);
        bool ChangeItemName(string currentName, string newName);
    }
}
