using UnityEngine;
using System;

public class Slot : Inventory
{
    public event Action OnInventoryChanged;

    // Adding item to inventory
    public bool AddItem(Item newItem)
    {
        for (int i = 0; i < amountOfSlots; i++)
        {
            if (Items[i] != null &&
                Items[i].itemName == newItem.itemName &&
                Items[i].currentStack < Items[i].maxStack)
            {
                Items[i].currentStack++;
                OnInventoryChanged?.Invoke();
                return true;
            }

            else if (Items[i] != null)
            {
                Items[i] = newItem;
                OnInventoryChanged?.Invoke();
                return true;
            }
        }

        Debug.Log("The Inventory Is Full!");
        return false;
    }

    // Adding an item to a certain slot
    public bool AddItemToSlot(Item newItem, int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= amountOfSlots)
        {
            Debug.LogError("Incorrect Slot Index!");
            return false;
        }

        if (Items[slotIndex] == null)
        {
            Items[slotIndex] = newItem;
            OnInventoryChanged?.Invoke();
            return true;
        }
        else if (Items[slotIndex].itemName == newItem.itemName &&
                Items[slotIndex].currentStack < Items[slotIndex].maxStack)
        {
            Items[slotIndex].currentStack++;
            OnInventoryChanged?.Invoke();
            return true;
        }

        Debug.Log("The Slot Is Full Or The Stack Is Full!");
        return false;
    }

    // Removing an item
    public void RemoveItem(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= amountOfSlots)
        {
            Debug.LogError("Incorrect Slot Index!");
            return;
        }

        if (Items[slotIndex] != null)
        {
            Items[slotIndex].currentStack--;

            if (Items[slotIndex].currentStack <= 0)
            {
                Destroy(Items[slotIndex].gameObject);
                Items[slotIndex] = null;
            }

            OnInventoryChanged?.Invoke();
        }
    }

    // Removing an item from a certain slot
    public Item GetItem(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= amountOfSlots)
        {
            Debug.LogError("Incorrect Slot Index!");
            return null;
        }

        OnInventoryChanged?.Invoke();
        return Items[slotIndex];
    }

    // Swaping the items in the slots
    public void SwapItems(int slotIndexA, int slotIndexB)
    {
        if (slotIndexA < 0 || slotIndexA >= amountOfSlots ||
            slotIndexB < 0 || slotIndexB >= amountOfSlots)
        {
            Debug.LogError("Incorrect Slot Index!");
            return;
        }

        Item temp = Items[slotIndexA];
        Items[slotIndexA] = Items[slotIndexB];
        Items[slotIndexB] = temp;

        OnInventoryChanged?.Invoke();
    }

    // Checking if there is an item in the inventory
    public bool HasItem(string itemName, int count = 1)
    {
        int total = 0;

        foreach (Item item in Items)
        {
            if (item != null && item.itemName == itemName)
            {
                total += item.currentStack;
                if (total >= count) return true;
            }
        }

        return false;
    }

    // Using item
    public void UseItem(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= amountOfSlots)
        {
            Debug.LogError("Incorrect Slot Index!");
            return;
        }

        if (Items[slotIndex] != null)
        {
            Items[slotIndex].ItemUse();

            // If an item is stackable
            if (Items[slotIndex].GetItemType() == ItemType.Consumable)
            {
                RemoveItem(slotIndex);
            }
        }
        OnInventoryChanged?.Invoke();
    }
}
