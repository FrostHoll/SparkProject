using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Interaction : MonoBehaviour
{
    private InputSystem_Actions inputActions;
    private GameObject nearestItem;
    private float minDistance = float.MaxValue;

    private void Awake()
    {
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
            IInteractable interactable = nearestItem.GetComponent<IInteractable>();
            interactable.Interact(gameObject);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (nearestItem == other.gameObject)
        {
            nearestItem = null;
            minDistance = float.MaxValue;
        }
    }
    
    private void OnTriggerStay(Collider other) 
    {
        if (other.gameObject.TryGetComponent<IInteractable>(out var interactable)) 
        {
            var distance = Vector3.Distance(transform.position, other.gameObject.transform.position);
            if (distance < minDistance)
            {
                nearestItem = other.gameObject;
                minDistance = distance;
            }
        }
    }
}