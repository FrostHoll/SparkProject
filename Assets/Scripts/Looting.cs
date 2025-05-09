using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Looting : MonoBehaviour
{
    // собственно иде€ - несколько типов сундуков, из которых могут выпадать разные типы предметов. “о ест items1 - лист предметов дл€ определЄнного типа сундуков items1

    public System.Random rnd = new System.Random();
    public Dictionary<string, int> items1 = new Dictionary<string, int>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        items1.Add("1 монетка", 30);
        items1.Add("2 монетки", 20);
        items1.Add("3 монетки", 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GiveMeFromItems1(Dictionary<string, int> items)
    {
        List<int> chances = new List<int>();
        List<string> stringitems = new List<string>();
        int sum=0;
        foreach (var x in items)
        {
            sum += x.Value;
            chances.Add(x.Value);
            stringitems.Add(x.Key);
        }
        for (int i=1;i<chances.Count;i++)
        {
            chances[i] += chances[i - 1]; 
        }
        int rndchsilo = rnd.Next(1, sum+1);
        for (int i = 0; i < chances.Count; i++)
        {
            if (i==0)
            {
                if( rndchsilo < chances[i] )
                {
                    return stringitems[i];
                }
            }
            else if( rndchsilo > chances[i-1] && rndchsilo < chances[i] )
            {
                return stringitems[i];
            }
        }
        return "WTH";
    }
}
