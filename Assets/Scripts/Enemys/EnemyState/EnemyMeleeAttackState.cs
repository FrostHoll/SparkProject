using UnityEngine;

public class EnemyMeleeAttackState : EnemyState
{
    public EnemyMeleeAttackState(EnemyController enemyController, Model enemyModel, BaseWeapon baseWeapon)
        : base(enemyController, enemyModel, baseWeapon)
    {

    }

    public override void StateExecute()
    {
        if (enemyController.isAngry)
        {
            enemyMovement.MoveEnemy(player.position, model.stats.Speed);
            enemyMovement.LookAtTarget(player);
            if (Vector3.Distance(player.position, enemyMovement.transform.position) <= model.stats.AttackRange)
            {
                weapon.StartOrStopAttack(true);
                view.StartAttackAnim();
                enemyMovement.agent.isStopped = true;
            }
            else
            {
                weapon.StartOrStopAttack(false);
                view.StopAttackAnim();
                enemyMovement.agent.isStopped = false;
            }
        }
        else
        {
            enemyController.TransitionToState(baseEnemy.CreateEnemyPatrulState(enemyController, model, weapon));
        }
        
    }
}
