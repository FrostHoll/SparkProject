using UnityEngine;
using UnityEngine.AI;

public class BaseEnemy : MonoBehaviour
{
    [Header("EnemyStats")]
    public float rotationSpeed = 45f;
    public float lookRadius = 10;
    public float enemyDamage = 10f;

    private NavMeshAgent nma;
    private Animator animator;
    private Transform player;
    private bool isAtac = false;

    private void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = FindFirstObjectByType<PlayerMovement>().transform;
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if(distance <= lookRadius)
        {
            nma.SetDestination(player.position);
        }

        if (isAtac)
        {
            nma.isStopped = true;
            LookAtPlayer(player);
        }
        else
        {
            nma.isStopped = false;
        }
    }

    private void LookAtPlayer(Transform target) //поворачивает с сторону таргета
    {
        Vector3 targetDirection = target.position - transform.position;
        targetDirection.y = 0;
        Quaternion targetEnemyRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetEnemyRotation, Time.deltaTime * rotationSpeed);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            isAtac = true;
            animator.SetBool("IsAtaking", isAtac);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isAtac = false;
            animator.SetBool("IsAtaking", isAtac);
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void EnemyAtak()
    {
        player.GetComponent<Health>().TakeDamage(enemyDamage);
    }
}
