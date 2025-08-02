using UnityEngine;

public class GravityCrushAttackState : EnemyState
{
    private float timeToJump = 2;
    private float timer = 0;

    private Rigidbody rb;

    public GravityCrushAttackState(EnemyController enemyController, Model enemyModel, BaseWeapon baseWeapon)
        : base(enemyController, enemyModel, baseWeapon)
    {
        rb = enemyController.GetComponent<Rigidbody>();
        timeToJump /= model.calculatedAttackSpeed;
        timer = timeToJump;
    }



    public override void StateExecute()
    {
        if (enemyController.isAngry && player != null)
        {
            weapon.StartOrStopAttack(!enemyMovement.GroundCheck());
            if (timer <= 0)
            {
                weapon.StartOrStopAttack(false);
                enemyMovement.Jump(15, 80, player.position);
                rb.useGravity = false;
                enemyController.TransitionToState(new HoveringAndKrushState(enemyController, model, weapon));
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
        else
        {
            baseEnemy.CreateEnemyPatrulState(enemyController, model, weapon);
        }
    }
}
