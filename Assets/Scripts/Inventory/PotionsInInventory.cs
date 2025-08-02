using UnityEngine;

public class PotionsInInventory : Inventory
{
    public PotionsInInventory()
    {
        amountOfSlots = 12;
        Items = new Item[amountOfSlots];
    }
    public Item[] GetPotions() { return Items; }
}
