using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryInputs : MonoBehaviour
{
    private QuickAccessToolbarController toolbarController;
    [SerializeField] private GameObject inventory;
    private InputSystem_Actions inputActions;
    [HideInInspector]public bool isInventoryOpen = false;

    public static InventoryInputs inventoryInputs;

    public void Initialization(QuickAccessToolbarController quickAccessToolbarController)
    {
        toolbarController = quickAccessToolbarController;
    }
    private void Awake()
    {
        inventoryInputs = this;
        inputActions = new InputSystem_Actions();
        inputActions.Enable();
        inventory.SetActive(false);
    }

    private void OnEnable()
    {
        inputActions.Player.HotKey1.performed += EquipWeapon1;
        inputActions.Player.HotKey2.performed += EquipWeapon2;
        inputActions.Player.Inventory.performed += InventoryOpened;
    }
    private void OnDisable()
    {
        inputActions.Player.HotKey1.performed -= EquipWeapon1;
        inputActions.Player.HotKey2.performed -= EquipWeapon2;
        inputActions.Player.Inventory.performed -= InventoryOpened;
    }

    private void Update()
    {
        float scroll = inputActions.Player.MouseScroll.ReadValue<Vector2>().y;

        if (scroll != 0)
        {
            if (scroll > 0)
            {
                toolbarController.EquipNextWeapon();
            }
            else
            {
                toolbarController.EquipNextWeapon();
            }
        }
    }

    private void EquipWeapon1(InputAction.CallbackContext obj)
    {
        toolbarController.EquipWeapon(0);
    }

    private void EquipWeapon2(InputAction.CallbackContext obj)
    {
        toolbarController.EquipWeapon(1);
    }

    private void InventoryOpened(InputAction.CallbackContext obj)
    {
        isInventoryOpen = !isInventoryOpen;
        inventory.SetActive(!inventory.activeSelf); 
    }
}
