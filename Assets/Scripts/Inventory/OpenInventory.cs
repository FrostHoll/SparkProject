using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    private Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false; // Disabling inventory at startup
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            canvas.enabled = !canvas.enabled; // Disabling/enabling inventory
        }
    }
}