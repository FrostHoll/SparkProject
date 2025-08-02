using UnityEngine;
using UnityEngine.InputSystem;

public class OpenInventory : MonoBehaviour
{
    private GameObject inventory;
    private InputSystem_Actions inputActions;

    void Start()
    {
        inventory.SetActive(false); // Disabling inventory at startup
    }

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Enable();
    }
    private void OnEnable()
    {
        inputActions.Player.Inventory.performed += InventoryOpened;
    }
    private void OnDisable()
    {
        inputActions.Player.Inventory.performed -= InventoryOpened;
    }

    private void InventoryOpened(InputAction.CallbackContext obj)
    {
        inventory.SetActive(!inventory.activeSelf); // Disabling/enabling inventory
    }
}