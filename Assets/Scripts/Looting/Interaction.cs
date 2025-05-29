using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    private InputSystem_Actions inputActions;
    private Interactable nearestItem;
    private float minDistance = float.MaxValue;
    private PlayerController playerController;

    private void Awake()
    {
        if (TryGetComponent<PlayerController>(out var playerControllert))
            playerController = playerControllert;
        inputActions = new InputSystem_Actions();
        inputActions.Enable();
    }
    private void OnEnable()
    {
        inputActions.Player.Interacte.performed += InteractePerformed;
    }
    private void OnDisable()
    {
        inputActions.Player.Interacte.performed -= InteractePerformed;
    }

    private void InteractePerformed(InputAction.CallbackContext obj)
    {
        if (nearestItem != null)
        {
            nearestItem.Interact(playerController);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        nearestItem = null;
        minDistance = float.MaxValue;
    }
    
    private void OnTriggerStay(Collider other) 
    {
        if (other.gameObject.TryGetComponent<Interactable>(out var interactable)) 
        {
            var distance = Vector3.Distance(transform.position, other.gameObject.transform.position);
            if (distance < minDistance)
            {
                nearestItem = interactable;
                minDistance = distance;
            }
        }
    }
}