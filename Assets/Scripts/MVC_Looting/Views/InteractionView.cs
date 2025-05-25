using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionView : MonoBehaviour
{
    private InteractionController _controller;
    public InputSystem_Actions InputActions;
    private void Awake()
    {
        _controller = GetComponent<InteractionController>();
        InputActions = new InputSystem_Actions();
        InputActions.Enable();
    }
    private void OnEnable()
    {
        InputActions.Player.Interacte.performed += InteractPerformed;
    }
    private void OnDisable()
    {
        InputActions.Player.Interacte.performed -= InteractPerformed;
    }

    private void InteractPerformed(InputAction.CallbackContext obj)
    {
        _controller.Interact();
    }
}