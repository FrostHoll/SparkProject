using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "LootTable", menuName = "Loot")]
public class LootTableModel : ScriptableObject
{
    [SerializeField] public List<ItemDrop> Items;

    public GameObject GetRandomItem()
    {
        if (Items == null || Items.Count == 0) return null;

        int sumWeight = Items.Sum(x => x.Weight);
        int randomValue = Random.Range(1, sumWeight + 1);

        int currentWeight = 0;
        foreach (var item in Items)
        {
            currentWeight += item.Weight;
            if (randomValue < currentWeight)
            {
                return item.GameObject;
            }
        }
        
        return null;
    }
}