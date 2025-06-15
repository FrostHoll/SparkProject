using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [Header("BlinkStats")]
    public float teleportMaxRadius = 10f;
    public float teleportMinRadius = 6f;
    public float teleportHeight = 0.5f;

    public float rotationSpeed = 4f;

    public NavMeshAgent agent;

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
}
