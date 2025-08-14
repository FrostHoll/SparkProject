using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Inventory")]
    public InventorySlot[] weaponSlots;
    public InventorySlot[] skillSlots;
    public InventorySlot[] throwablesSlots;
    public InventorySlot[] potionsSlots;
    [Header("QuickAccessToolbar")]
    public InventorySlot[] weapons;
    public InventorySlot[] skills;

    public GameObject inventoryItemPrefab;

    public void AddItem(Item item)
    {
        switch(item.type)
        {
            case ItemType.Weapon:
                if (!AddItemToSlot(weapons, item))
                {
                    AddItemToSlot(weaponSlots, item);
                }
                break;
            case ItemType.Skill:
                if(!AddItemToSlot(skills, item))
                {
                    AddItemToSlot(skillSlots, item);
                }
                break;
            case ItemType.Throwable:
                AddItemToSlot(throwablesSlots, item); 
                break;
            case ItemType.Potion:
                AddItemToSlot(potionsSlots, item);
                break;
            case ItemType.Artifact:

                break;
        }
    }

    void SpawnNewItem(Item item, InventorySlot slot, int index)
    {
        GameObject newItemGO = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGO.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item, index, slot.inventoryListType);
    }

    bool AddItemToSlot(InventorySlot[] inventorySlots, Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if(itemInSlot == null)
            {
                SpawnNewItem(item, slot, i);
                return true;
            }
        }
        return false;
    }

    public void InitializationPlayerInventory(PlayerController playerController)
    {
        InitializationInventoryList(weaponSlots, playerController);
        InitializationInventoryList(skillSlots, playerController);
        InitializationInventoryList(throwablesSlots, playerController);
        InitializationInventoryList(potionsSlots, playerController);
        InitializationInventoryList(weapons, playerController);
        InitializationInventoryList(skills, playerController);
    }

    private void InitializationInventoryList(InventorySlot[] inventorySlots, PlayerController playerController)
    {
        for(int i = 0;i < inventorySlots.Length; i++)
        {
            inventorySlots[i].SetPlayerController(playerController);
        }
    }
}
