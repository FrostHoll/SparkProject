using UnityEngine;

public class WizardRangeAttackState : EnemyState
{
    public float teleportTime = 4f; 
    private float timer;

    public WizardRangeAttackState(EnemyController enemyController, Model enemyModel, BaseWeapon baseWeapon)
        : base(enemyController, enemyModel, baseWeapon)
    {

    }

    public override void StateExecute()
    {
        if (enemyController.isAngry)
        {
            enemyMovement.agent.isStopped = true;
            enemyMovement.LookAtTarget(player);
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                view.animator.SetTrigger("isTeleporting");
                timer = teleportTime;
            }
        }
        else
        {
            enemyMovement.agent.isStopped = false;
            enemyController.TransitionToState(baseEnemy.CreateEnemyPatrulState(enemyController, model, weapon));
        }
    }
}
