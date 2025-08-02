using UnityEngine;

public class SlimeAttackState : EnemyState
{
    public float jumpTimer = 2f;
    private float timer = 0;
    private bool graundet = true;

    public SlimeAttackState(EnemyController enemyController, Model enemyModel, BaseWeapon baseWeapon)
        : base(enemyController, enemyModel, baseWeapon)
    {

    }

    public override void StateExecute()
    {
        if (enemyController.isAngry && player != null)
        {
            enemyMovement.LookAtTarget(player);
            graundet = enemyMovement.GroundCheck();
            weapon.StartOrStopAttack(!graundet);
            if (timer <= 0 && graundet)
            {
                enemyMovement.Jump(30, 35, player.position);
                timer = jumpTimer / model.calculatedAttackSpeed;
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
