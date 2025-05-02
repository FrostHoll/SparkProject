using UnityEngine;

public class EnemyWithStick : BaseEnemy
{
    [SerializeField] private EnemyAttackTrigger attackTrigger;

    public override void Attack()
    {
        attackTrigger.EnemyAttack();
    }

    public override void MoveEnemy(Transform target)
    {
        agent.SetDestination(target.position);
    }
}
