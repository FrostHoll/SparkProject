using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [Header("BlinkStats")]
    public float teleportMaxRadius = 10f;
    public float teleportMinRadius = 6f;
    public float teleportHeight = 0.5f;
    [Header("Ground Check")]
    public float enemyHight = 0.2f;
    public LayerMask whatIsGrount;
    public bool graundet;
    [Header("Rotation")]
    public float rotationSpeed = 4f;
    [Header("Levitation")]
    public float levitationHeight = 1f;
    public float levitationSpeed = 0.5f;
    public float dampingFactor = 0.5f;
    [Header("Other")]
    public NavMeshAgent agent;
    private Rigidbody rb;

    public bool GroundCheck() // проеверка есть ли пол под enemy
    {
        return graundet = Physics.Raycast(transform.position, Vector3.down, enemyHight * 0.5f + 0.2f, whatIsGrount);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void LookAtTarget(Transform target) //поворачивает в сторону таргета
    {
        Vector3 targetDirection = target.position - transform.position;
        targetDirection.y = 0;
        Quaternion targetEnemyRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetEnemyRotation, Time.deltaTime * rotationSpeed);
    }

    public void MoveEnemy(Vector3 target, float speed)
    {
        agent.speed = speed; 
        agent.SetDestination(target);
    }

    public void Blink(Transform player)
    {
        transform.position = RandomTransformGenerator.CreateRandomTransformNearObject(player, teleportMaxRadius, teleportMinRadius, teleportHeight);
    }

    public void Jump(float jumpForce, float jumpAngle, Vector3 target)
    {
        Vector3 direction = target - transform.position;
        direction.y = 0f; 
        direction = direction.normalized;

        float verticalSpeed = Mathf.Sin(jumpAngle * Mathf.Deg2Rad) * jumpForce;
        float horizontalSpeed = Mathf.Cos(jumpAngle * Mathf.Deg2Rad) * jumpForce;

        rb.AddForce(direction * horizontalSpeed + Vector3.up * verticalSpeed, ForceMode.Impulse);
    }

    public void Levitation()
    {
        float distance = levitationHeight - transform.position.y; //незнаю будет возвышености или наобарот провалы. Но пока оставлю так.

        float force = distance * levitationSpeed;

        force -= rb.linearVelocity.y * dampingFactor;
        rb.AddForce(Vector3.up * force, ForceMode.Force);

    }

    public void MoveForward(float speed)
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
