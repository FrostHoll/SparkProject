using UnityEngine;

public enum ItemType
{
    Weapon,
    Skill,
    Throwable,
    Potion,
    Artifact
}


public abstract class Item : ScriptableObject
{ 
    public string itemName;
    public Sprite image;
    public ItemType type;
    public bool stackable = false;
    public int maxStack = 1;
    public int currentStack = 1;
}
