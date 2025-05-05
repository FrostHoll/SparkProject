using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR.Haptics;

class Dash : MonoBehaviour, IDash
{
    private InputSystem_Actions inputActions;

    private Rigidbody rb;
    private PlayerMovement ms;
    private PlayerLookAtMouse plams;

    [SerializeField] private float timeOfDash = 0.5f;
    [SerializeField] private float dashIncreaseSpeed = 5f;

    public float TeckTimer;

    public bool DASH = false;
    
    public float TimeOfDash
    {
        get { return timeOfDash; }
        set { timeOfDash = value; }
    }
    public float DashIncreaseSpeed
    {
        get { return dashIncreaseSpeed; }
        set { dashIncreaseSpeed = value; }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            TeckTimer = TimeOfDash;
            ms.enabled = false;
            plams.enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
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

interface IDash
{
    float TimeOfDash { get; set; }
    float DashIncreaseSpeed { get; set; }
}
