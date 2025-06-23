using UnityEngine;

public abstract class Item : MonoBehaviour
{ 
    public string itemName;
    public Sprite icon;
    public int maxStack = 1;
    public int currentStack = 1;

    public abstract string GetItemType();
    public abstract void ItemUse();
}
