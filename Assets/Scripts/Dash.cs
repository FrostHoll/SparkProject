using UnityEngine;
using UnityEngine.InputSystem;

public class Dash : MonoBehaviour
{
    public InputAction playerControls;
    private Rigidbody rb;
    public float TimeOfDash = 1f;
    public float TeckTimer = 0f;
    // public float DashIncreaseSpeed = 5f;  Я хотел добавить х увеличение скорости, но не решился редактировать PlayerMovement, чтобы создать метод возврата скорости(
    public float PlayerDashSpeed = 15f;
    public bool DASH = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (!DASH) {
                DASH = true;
                TeckTimer = TimeOfDash;
            }
        }
        if (DASH == true)
        {
            TeckTimer -= Time.deltaTime;
            rb.linearVelocity = transform.forward * PlayerDashSpeed;
        }
        if (TeckTimer <= 0)
        {
            DASH = false;
        }
    }
}
