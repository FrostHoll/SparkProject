using UnityEngine;
using UnityEngine.AI;

public abstract class BaseEnemy : MonoBehaviour
{
    public EnemyStats enemyStats;
    public float rotationSpeed = 2f;

    public bool isAngry = false;

    public NavMeshAgent agent;
    public Transform player;
    public Animator animator;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        GetComponent<SphereCollider>().radius = enemyStats.AgrRadius;
        agent.speed = enemyStats.Speed;
        animator.speed = enemyStats.AttackSpeed; //временно
    }

    private void Update()
    {
        if (isAngry)
        {
            MoveEnemy(player);
        }
    }

    

    public void LookAtTarget(Transform target) //поворачивает в сторону таргета
    {
        Vector3 targetDirection = target.position - transform.position;
        targetDirection.y = 0;
        Quaternion targetEnemyRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetEnemyRotation, Time.deltaTime * rotationSpeed);
    }

    public abstract void MoveEnemy(Transform target);

    public abstract void Attack();
}
