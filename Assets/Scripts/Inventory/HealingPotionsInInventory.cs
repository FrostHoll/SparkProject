using UnityEngine;

public class HealingPotionsInInventory : Inventory
{
    public HealingPotionsInInventory()
    {
        amountOfSlots = 4;
        Items = new Item[amountOfSlots];
    }
    public Item[] GetHealingPotions() { return Items; }
}
