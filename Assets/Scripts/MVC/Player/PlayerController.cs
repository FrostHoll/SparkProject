using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Controller
{
    public InputAction playerControls;
    public PlayerView playerView;
    private Rigidbody rb;

    private void Start()
    {
        playerControls.Enable();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var inputs = playerControls.ReadValue<Vector2>().normalized;

        if (inputs != Vector2.zero)
        {
            rb.linearVelocity = new Vector3(inputs.x, 0f, inputs.y) * baseStats.Speed;
        }

        if (Input.GetKeyUp(KeyCode.E)) //для проверки
        {
            ApplyHealing(10f);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            TakeDamage(10f);
        }

        healthBar.HealthBarRenderer(baseStats.HP,baseStats.MaxHP);
    }
}
