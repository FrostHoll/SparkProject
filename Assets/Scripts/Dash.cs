using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR.Haptics;

public class Dash : MonoBehaviour
{
    public InputAction playerControls;
    private Rigidbody rb;
    private PlayerMovement ms;
    private PlayerLookAtMouse plams;
    public float TimeOfDash = 1f;
    public float TeckTimer = 0f;
    public float DashIncreaseSpeed = 5f;
    public bool DASH = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ms = GetComponent<PlayerMovement>();
        plams = GetComponent<PlayerLookAtMouse>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (!DASH) {
                DASH = true;
                TeckTimer = TimeOfDash;
                ms.enabled = false;
                plams.enabled = false;
            }
        }
        if (DASH == true)
        {
            TeckTimer -= Time.deltaTime;
            rb.linearVelocity = transform.forward * DashIncreaseSpeed * ms.speed;
        }
        if (TeckTimer <= 0)
        {
            DASH = false;
            ms.enabled = true;
            plams.enabled = true;
        }
    }
}
