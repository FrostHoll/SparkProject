using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    public float enemyDamage = 10f;
    public float weaponLength = 2;
    public bool isAttacking = false;
    public LayerMask layerMask; // с чем будет взаимодействовать

    private void Update()
    {
        if (isAttacking) 
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position,-transform.up, out hit,weaponLength , layerMask))
            {
                if (hit.transform.TryGetComponent(out Health health))
                {
                    health.TakeDamage(enemyDamage);
                    isAttacking = false;
                }
            }
        }
    }

    private void OnDrawGizmos() // просто показывает облость рейкаста
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position,transform.position - transform.up * weaponLength);
    }
}
