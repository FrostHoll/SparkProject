using UnityEngine;
using System.Collections.Generic;

public class Looting
{
    public GameObject GiveMeFromItems(List<ItemDrop> items)
    {
        List<int> chances = new List<int>();
        List<GameObject> gameitems = new List<GameObject>();
        int sum=0;
        foreach (var x in items)
        {
            sum += x.weight;
            chances.Add(x.weight);
            gameitems.Add(x.gameObject);
        }
        for (int i=1;i<chances.Count;i++)
        {
            chances[i] += chances[i - 1]; 
        }
        int rndchsilo = Random.Range(1, sum+1);
        for (int i = 0; i < chances.Count; i++)
        {
            if (i==0)
            {
                if( rndchsilo < chances[i] )
                {
                    return gameitems[i];
                }
            }
            else if( rndchsilo > chances[i-1] && rndchsilo < chances[i] )
            {
                return gameitems[i];
            }
        }
        return null;
    }
}
