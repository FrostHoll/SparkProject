using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Interaction : MonoBehaviour
{
    private InputSystem_Actions inputActions;
    public List<string> ListOfItemsInInteractionZone = new List<string>();
    public bool Interacting = false;
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InteractePerformed(InputAction.CallbackContext obj)
    {
        Interacting = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("� ������� �����: " + other.name);
        ListOfItemsInInteractionZone.Add(other.name);
        //Debug.Log("������: " + string.Join(", ", ListOfItemsInInteractionZone));
        if (ListOfItemsInInteractionZone.Contains(other.name))
        {
            Debug.Log("�� ��");
        }
        else
        {
            Debug.Log("�� �� ��!!!");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("�� ������� �����: " + other.name);
        ListOfItemsInInteractionZone.Remove(other.name);
        //Debug.Log("������: " + string.Join(", ", ListOfItemsInInteractionZone));
    }
}
