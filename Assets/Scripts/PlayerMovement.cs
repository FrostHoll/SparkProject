using UnityEngine;
using UnityEngine.InputSystem;

public interface IMoveSpeed
{
    float Speed { get; set; }
}

public class PlayerMovement : MonoBehaviour
{
    public InputAction playerControls;

    [SerializeField] private CharacterStats characterStats;

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
            rb.linearVelocity = new Vector3(inputs.x, 0f, inputs.y) * characterStats.Speed;
        }
    }
}
