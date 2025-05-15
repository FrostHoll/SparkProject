using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Interaction : MonoBehaviour, IInteraction
{
    private InputSystem_Actions inputActions;

    [SerializeField] private bool interacting = false;
    private List<GameObject> listOfItemsInInteractionZone = new List<GameObject>();

    public bool Interacting { get { return interacting; } set { interacting = value; } }
    public List<GameObject> ListOfItemsInInteractionZone { get { return listOfItemsInInteractionZone; } set { listOfItemsInInteractionZone = value; } }
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
        if (listOfItemsInInteractionZone.Count > 0)
        { 
            float minDistance = float.MaxValue;
            GameObject nearestItem = null;
            Vector3 playerPosition = transform.position;

            foreach (var item in listOfItemsInInteractionZone)
            {
                float distance = Vector3.Distance(playerPosition, item.transform.position);
                if (distance < minDistance)
                {
                    nearestItem = item;
                    minDistance = distance;
                }
            }  
            

            IInteractable interactable = nearestItem.GetComponent<IInteractable>();
            interactable.Interact();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ListOfItemsInInteractionZone.Add(other.gameObject);

    }
    private void OnTriggerExit(Collider other)
    {
        ListOfItemsInInteractionZone.Remove(other.gameObject);
    }
}

interface IInteraction
{
    bool Interacting { get; set; }
    List<GameObject> ListOfItemsInInteractionZone { get; set; }
}

