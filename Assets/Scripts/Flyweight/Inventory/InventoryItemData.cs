using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "Data/ItemData")]
public class InventoryItemData : ScriptableObject
{
    [SerializeField] private string itemID;
    [SerializeField] private int maxItemStack;

    [SerializeField] private UsabilityData usabilityData;
    [SerializeField] private StaticInfoData staticInfoData;
    public int MaxItemStack => maxItemStack;
    public string ItemID => itemID;

    public void Use()
    {
        usabilityData.Use();
    }

    public StaticInfoData GetInfoData()
    {
        return staticInfoData;
    }
}