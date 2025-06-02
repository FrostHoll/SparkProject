using UnityEngine;

public class EnemyWithStick : BaseEnemy
{
    public override void EnemyAI(EnemyMovement enemyMovement, Transform player, View view, Model model, BaseWeapon weapon = null)
    {
        enemyMovement.MoveEnemy(player, model.stats.Speed);
        enemyMovement.LookAtTarget(player);
        if (Vector3.Distance(player.position, transform.position) <= model.stats.AttackRange)
        {
            weapon.StartOrStopAttack(true);
            view.ChangeAttackAnim(true);
            enemyMovement.agent.isStopped = true;
        }
        else
        {
            weapon.StartOrStopAttack(false);
            view.ChangeAttackAnim(false);
            enemyMovement.agent.isStopped = false;
        }
    }
}
