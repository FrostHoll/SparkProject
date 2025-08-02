using UnityEngine;

public class WeaponsInInventory : Inventory
{
    public WeaponsInInventory()
    {
        amountOfSlots = 6; // 4/2
        Items = new Item[amountOfSlots];
    }
    public Item[] GetWeapons() { return Items; }
    public Item[] GetSelectedWeapon()
    {
        Item[] result = new Item[4];
        for (int i = 0; i < 4; i++)
        {
            result[i] = Items[i];
        }

        return result;
    }
}
