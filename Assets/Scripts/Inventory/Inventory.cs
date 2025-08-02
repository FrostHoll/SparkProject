using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    public int amountOfSlots { get; protected set; }
    protected Item[] Items;

    protected Inventory() {}

    // potions = 12
    // healing potions = 4
    // skills = 4 (2/2, 2 choosed and 2 in inventory)
    // weapons = 4 (2/2)
    // throwing weapons = 6 (4/2)

    private InputSystem_Actions inputActions;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Enable();
    }

    public InputAction playerControls;

    private void OnEnable()
    {
        inputActions.Player.HotKey.performed += Items[slotIndex].ItemUse;
    }
    private void OnDisable()
    {
        inputActions.Player.HotKey.performed -= Items[slotIndex].ItemUse;
    }
}
