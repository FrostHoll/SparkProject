using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    [SerializeField] private EnemyStats enemyStats;

    public bool isAttacking = false;
    public LayerMask layerMask; // с чем будет взаимодействовать

    private void Update()
    {
        if (isAttacking) 
        {
            RaycastHit hit;
            
            if (Physics.Raycast(transform.position,-transform.up, out hit,enemyStats.AttackRange , layerMask))
            {
                if (hit.transform.TryGetComponent(out Controller health))
                {
                    health.TakeDamage(enemyStats.Damage);
                    isAttacking = false;
                }
            }
        }
    }

    private void OnDrawGizmos() // просто показывает облость рейкаста
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * enemyStats.AttackRange);
    }
}
