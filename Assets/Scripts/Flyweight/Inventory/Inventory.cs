using System.Collections.Generic;

namespace Flyweight.Inventory
{
    public class Inventory
    {
        // private List<InventoryItem> currentlyHeldItems;
        private Dictionary<string, InventoryItem> heldItems;

        public void AddItem(InventoryItemData newItem, int amount)
        {
            if (heldItems.TryGetValue(newItem.ItemID, out var itemData))
            {
                itemData.Amount += amount;
                heldItems[newItem.ItemID] = itemData;
                return;
            }

            heldItems.Add(newItem.ItemID, new InventoryItem() { Amount = amount, Data = newItem });
        }

        public InventoryItem GetItem(string itemID)
        {
            if (heldItems.TryGetValue(itemID, out var value))
            {
                return value;
            }

            return default;
        }

        public bool UseItem(string itemID)
        {
            if (heldItems.TryGetValue(itemID, out var value))
            {
                value.Data.Use();
                return true;
            }

            return false;
        }

        public StaticInfoData GetItemInfo(string itemID)
        {
            if (heldItems.TryGetValue(itemID, out var value))
            {
                return value.Data.GetInfoData();
            }

            return null;
        }
    }
}

[System.Serializable]
public struct InventoryItem
{
    public int Slot;
    public int Amount;
    public InventoryItemData Data;
}
//
// public class CombinationTable : ScriptableObject
// {
//     private List<CombinationData> combinations;
//
//     public InventoryItemData GetCombination(string itemAId, string itemBId)
//     {
//         
//     }
// }

public struct CombinationData
{
    public string itemAId;
    public string itemBId;
    public InventoryItemData combination;
}