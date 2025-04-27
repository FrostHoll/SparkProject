using UnityEngine;
using UnityEngine.AI;

public class BaseEnemy : MonoBehaviour
{
    public float rotationSpeed = 45f;

    public NavMeshAgent agent;
    [SerializeField] EnemyAttackTrigger enemyAttackTrigger;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void LookAtTarget(Transform target) //поворачивает с сторону таргета
    {
        Vector3 targetDirection = target.position - transform.position;
        targetDirection.y = 0;
        Quaternion targetEnemyRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetEnemyRotation, Time.deltaTime * rotationSpeed);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            agent.SetDestination(other.transform.position);
        }
    }

    public void Attack()
    {
        enemyAttackTrigger.EnemyAttack();
    }
}
