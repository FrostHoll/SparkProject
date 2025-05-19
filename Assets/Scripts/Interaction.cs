using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.InputSystem.LowLevel;

public class Interaction : MonoBehaviour
{
    private InputSystem_Actions inputActions;
    private GameObject nearestItem;
    private IInteractable nearestItemInterface; // < - пришлось его сделать, изначально хотел вместо GameObject только IInterctable оставить,
    private float minDistance = float.MaxValue; //  но для проверки OnTriggerExit тогда бы пришлось вызывать TryGetComponent, что ещё хуже чем было, так что теперь 2 поля.

    private IWhoIsUser nearestItemUser;

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
            nearestItemInterface.Interact();
        }
        if (nearestItemUser != null)
        {
            nearestItemUser.Player = gameObject;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (nearestItem == other.gameObject)
        {
            nearestItem = null;
            nearestItemInterface = null;
            nearestItemUser = null;
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
                nearestItemInterface = interactable;
                minDistance = distance;

                if (other.gameObject.TryGetComponent<IWhoIsUser>(out var whoIsUser))
                {
                    nearestItemUser = whoIsUser;
                }
                else
                {
                    nearestItemUser = null;
                }
            }
        }
    }
}