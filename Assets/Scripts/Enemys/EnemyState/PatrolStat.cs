using UnityEngine;

public class PatrolStat : EnemyState
{
    private Transform enemyPosition;

    //private float maxPatrolRadius = 4;
    //private float minPatrolRadius = 2;
    public PatrolStat(EnemyController enemyController, Model enemyModel, BaseWeapon baseWeapon)
        : base(enemyController, enemyModel, baseWeapon)
    {
        enemyPosition = enemyController.gameObject.transform;
    }

    public override void StateExecute()
    {
        if (enemyController.isAngry)
        {
            enemyController.TransitionToState(baseEnemy.CreateEnemyAttackState(enemyController,model,weapon));
        }
        else
        {
            enemyMovement.MoveEnemy(enemyPosition.position,model.stats.Speed);
        }
    }
}
