using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewDropItems", menuName = "Drop Item")]
public class DropItems : ScriptableObject
{
    [SerializeField] private string _listName;
    [SerializeField] private List<ItemDrop> _listItems;

    public string ListName => _listName;
    public List<ItemDrop> ListItems => _listItems;
}

[System.Serializable]
public class ItemDrop
{
    public GameObject gameObject;
    public int weight;
}