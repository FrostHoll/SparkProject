using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    private GameObject inventory;

    void Start()
    {
        inventory = GetComponent<GameObject>();
        inventory.SetActive(false); // Disabling inventory at startup
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            inventory.SetActive(!inventory.activeSelf); // Disabling/enabling inventory
        }
    }
}