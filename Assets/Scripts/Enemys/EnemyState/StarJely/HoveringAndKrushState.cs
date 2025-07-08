using UnityEngine;

public class HoveringAndKrushState : EnemyState
{
    private Rigidbody rb;
    private float timer;
    private float hoveringTime = 5f;

    public HoveringAndKrushState(EnemyController enemyController, Model enemyModel, BaseWeapon baseWeapon)
        : base(enemyController, enemyModel, baseWeapon)
    {
        rb = enemyController.GetComponent<Rigidbody>();
        timer = hoveringTime;
    }

    public override void StateExecute()
    {
        if (enemyController.isAngry)
        {
            if(timer <= 0)
            {
                rb.useGravity = true;
                enemyMovement.Jump(60, -90, player.position);
                weapon.StartOrStopAttack(true);
                enemyController.TransitionToState(new GravityCrushAttackState(enemyController, model, weapon));
            }
            else
            {
                timer -= Time.deltaTime;
                enemyMovement.Levitation();
                enemyMovement.MoveForward(model.stats.Speed);
                enemyMovement.LookAtTarget(player);
            }
        }
        else
        {
            baseEnemy.CreateEnemyPatrulState(enemyController, model, weapon);
        }
    }
}