using System;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class SecondLine : Inventory
{
    // The "hotKeys" slots, second line of the inventory
    // Functions:

    // - using item (new);

    // ( from Inventory "BottomLine": )
    // - adding item;
    // - adding item to a certain slot;
    // - removing item;
    // - getting item;
    // - swapping items in two slots;
    // - checking, if an item stored.

    [Header("Keys settings")]
    [SerializeField] private KeyCode abilityKey1 = KeyCode.Alpha1;
    [SerializeField] private KeyCode abilityKey2 = KeyCode.Alpha2;
    [SerializeField] private KeyCode abilityKey3 = KeyCode.Alpha3;
    [SerializeField] private KeyCode abilityKey4 = KeyCode.Alpha4;
    [SerializeField] private KeyCode abilityKey5 = KeyCode.Alpha5;
    [SerializeField] private KeyCode abilityKey6 = KeyCode.Alpha6;
    [SerializeField] private KeyCode abilityKey7 = KeyCode.Alpha7;
    [SerializeField] private KeyCode abilityKey8 = KeyCode.Alpha8;
    [SerializeField] private KeyCode abilityKey9 = KeyCode.Alpha9;
    [SerializeField] private KeyCode abilityKey0 = KeyCode.Alpha0;

    new public event Action OnInventoryChanged; // ?

    private void Update()
    {
        if (Input.GetKeyDown(abilityKey1))
        {
            UseItem(0);
        }
        if (Input.GetKeyDown(abilityKey2))
        {
            UseItem(1);
        }
        if (Input.GetKeyDown(abilityKey3))
        {
            UseItem(2);
        }
        if (Input.GetKeyDown(abilityKey4))
        {
            UseItem(3);
        }
        if (Input.GetKeyDown(abilityKey5))
        {
            UseItem(4);
        }
        if (Input.GetKeyDown(abilityKey6))
        {
            UseItem(5);
        }
        if (Input.GetKeyDown(abilityKey7))
        {
            UseItem(6);
        }
        if (Input.GetKeyDown(abilityKey8))
        {
            UseItem(7);
        }
        if (Input.GetKeyDown(abilityKey9))
        {
            UseItem(8);
        }
        if (Input.GetKeyDown(abilityKey0))
        {
            UseItem(9);
        }
    }

    // Using item
    public void UseItem(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= inventorySize)
        {
            Debug.LogError("Incorrect Slot Index!");
            return;
        }

        if (Items[slotIndex] != null)
        {
            Items[slotIndex].ItemUse();

            // If an item is stackable
            if (Items[slotIndex].GetItemType() == "Consumable") // Should be realised in class Item
            {
                RemoveItem(slotIndex);
            }
        }
        OnInventoryChanged?.Invoke();
    }
}
