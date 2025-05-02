using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    public float enemyDamage = 10f;
    private Health PlayerHealth;
    private bool isAttacking = false;
    [SerializeField] private Animator animator;
    [SerializeField] private EnemyWithStick baseEnemy;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth = other.GetComponent<Health>();
            baseEnemy.LookAtTarget(other.transform);
            ChangeEnemyAttackStatus(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeEnemyAttackStatus(false);
        }
    }

    private void ChangeEnemyAttackStatus(bool status)
    {
        isAttacking = status;
        baseEnemy.agent.isStopped = status;
        animator.SetBool("IsAttacking", status);
    }

    public void EnemyAttack()
    {
        if (isAttacking) PlayerHealth.TakeDamage(enemyDamage);
    }
}
