using UnityEngine;
using UnityEngine.InputSystem;

public interface IDash
{
    float TimeOfDash { get; set; }
    float DashIncreaseSpeed { get; set; }
}

class Dash : MonoBehaviour
{
    private InputSystem_Actions inputActions;

    private Rigidbody rb;
    private PlayerMovement ms;
    private PlayerLookAtMouse plams;

    public float TeckTimer;

    public bool DASH = false;

    [SerializeField] private CharacterStats characterStats;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ms = GetComponent<PlayerMovement>();
        plams = GetComponent<PlayerLookAtMouse>();
    }

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Enable();
    }

    private void OnEnable()
    {
        inputActions.Player.Dash.performed += DashPerformed;
    }
    private void OnDisable()
    {
        inputActions.Player.Dash.performed -= DashPerformed;
    }

    private void DashPerformed(InputAction.CallbackContext obj)
    {
        if (!DASH)
        {
            DASH = true;
            TeckTimer = characterStats.TimeOfDash;
            ms.enabled = false;
            plams.enabled = false;
        }
    }

    void Update()
    {
        if (DASH == true)
        {
            TeckTimer -= Time.deltaTime;
            rb.linearVelocity = transform.forward * characterStats.DashIncreaseSpeed * characterStats.Speed;
        }
        if (TeckTimer <= 0)
        {
            DASH = false;
            ms.enabled = true;
            plams.enabled = true;
        }
    }
}


