using UnityEngine;

public class ThrowingWeaponsInInventory : Inventory
{
    public ThrowingWeaponsInInventory()
    {
        amountOfSlots = 6; // 4/2
        Items = new Item[amountOfSlots];
    }
    public Item[] GetThrowingWeapons() { return Items; }
    public Item[] GetSelectedThrowingWeapon()
    {
        Item[] result = new Item[4];
        for (int i = 0; i < 4; i++)
        {
            result[i] = Items[i];
        }

        return result;
    }
}
