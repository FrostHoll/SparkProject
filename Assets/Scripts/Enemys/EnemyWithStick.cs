using UnityEngine;

public class EnemyWithStick : BaseEnemy
{
    public float attackRange = 2;
    [SerializeField] private EnemyMeleeAttack enemyMeleeAttack;

    private void Update()
    {
        if (isAngry)
        {
            MoveEnemy(player);
            LookAtTarget(player);
            if (Vector3.Distance(player.position,transform.position) <= attackRange)
            {
                Attack();
                agent.isStopped = true;
            }
            else
            {
                agent.isStopped = false;
                animator.SetBool("IsAttacking", false);
            }
        }
    }

    public override void Attack()
    {
        animator.SetBool("IsAttacking", true);
    }

    public override void MoveEnemy(Transform target)
    {
        agent.SetDestination(target.position);
    }

    private void OnDrawGizmos() // просто показывает облость рейкаста
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,attackRange);
    }

    public void AttackOn() //сробатывает в начале анимации
    {
        enemyMeleeAttack.isAttacking = true;
    }

    public void AttackOff() //сробатывает в конце анимации
    {
        enemyMeleeAttack.isAttacking = false;
    }
}
