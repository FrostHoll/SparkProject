using UnityEngine;

public class QuickAccessToolbarController 
{
    private Controller controller;
    private WeaponItem[] weaponSlots;
    private BaseWeapon currentWeapon;
    private int slotIndex;

    public QuickAccessToolbarController(Controller controller, WeaponItem[] weaponItems)
    {
        this.controller = controller;
        weaponSlots = weaponItems;
    }

    public void EquipNextWeapon()
    {
        slotIndex = (slotIndex + 1) % 2; 
        EquipWeapon(slotIndex);
    }

    public void EquipWeapon(int slotIndex)
    {
        controller.RemoveWeapon();
        currentWeapon = null;
        this.slotIndex = slotIndex;

        if (weaponSlots[this.slotIndex] != null)
        {
            currentWeapon = weaponSlots[this.slotIndex].weapon;
            controller.AddWeapon(currentWeapon);
        }
    }

    public void UpdateToolBar()
    {
        EquipWeapon(slotIndex);
    }
}
