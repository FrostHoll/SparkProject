using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "LootTable", menuName = "Loot")]
public class LootTable : ScriptableObject
{
    [SerializeField] private List<ItemDrop> items;

    public GameObject GetRandomItem()
    {
        if (items == null || items.Count == 0) return null;

        int sumWeight = items.Sum(x => x.weight);
        int randomValue = Random.Range(1, sumWeight + 1);

        int currentWeight = 0;
        foreach (var item in items)
        {
            currentWeight += item.weight;
            if (randomValue < currentWeight)
            {
                return item.gameObject;
            }
        }

        return null;
    }
}

[System.Serializable]
public class ItemDrop
{
    public GameObject gameObject;
    public int weight;
}