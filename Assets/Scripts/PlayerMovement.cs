using UnityEngine;
using UnityEngine.InputSystem;

public interface IMoveSpeed
{
    float Speed { get; set; }
}

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(InputAction playerControls,float speed)
    {
        var inputs = playerControls.ReadValue<Vector2>().normalized;

        if (inputs != Vector2.zero)
        {
            rb.linearVelocity = new Vector3(inputs.x, 0f, inputs.y) * speed;
        }
    }
}
