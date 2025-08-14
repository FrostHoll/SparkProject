using UnityEngine;

public enum WeaponType
{
    Sword
}

public class Weapon : Item
{
    public int maxSlots = 1;
    public float rarity;
    public WeaponType weaponType;

    public WeaponType GetWeaponType() { return weaponType; }
}
