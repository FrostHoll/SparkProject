using UnityEngine;

public class SkillsInInventory : Inventory
{
    public SkillsInInventory()
    {
        amountOfSlots = 4; // 2/2
        Items = new Item[amountOfSlots];
    }
    public Item[] GetSkills() { return Items; }
    public Item[] GetSelectedSkills()
    {
        Item[] result = new Item[2];
        for (int i = 0; i < 2; i++)
        {
            result[i] = Items[i];
        }

        return result;
    }
}
