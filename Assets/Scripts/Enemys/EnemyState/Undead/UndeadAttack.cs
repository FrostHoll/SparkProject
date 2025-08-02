using UnityEngine;

public class UndeadAttack : EnemyState
{
    public float jumpDistance = 4;
    public float jumpCooldown = 4f;
    public float timer;
    public UndeadAttack(EnemyController enemyController, Model enemyModel, BaseWeapon baseWeapon)
        : base(enemyController, enemyModel, baseWeapon)
    {
        timer = 0;
    }

    public override void StateExecute()
    {
        if (enemyController.isAngry && player != null)
        {
            if (Vector3.Distance(player.position, enemyMovement.transform.position) >= jumpDistance)
            {
                if(enemyMovement.agent.enabled == true)
                {
                    enemyMovement.MoveEnemy(player.position, model.stats.Speed);
                    enemyMovement.LookAtTarget(player);
                }

            }
            else
            {
                if(timer <= 0)
                {
                    enemyMovement.agent.enabled = false;
                    enemyMovement.Jump(25, 20, player.position);
                    weapon.StartOrStopAttack(true);
                    enemyController.GetComponent<CapsuleCollider>().isTrigger = true;
                    if(enemyController.TryGetComponent(out Killer killer))
                    {
                        killer.deathTime = 1;
                    }
                    timer = jumpCooldown;
                }
                else
                {
                    jumpCooldown -= Time.deltaTime;
                }
            }
        }
        else
        {
            enemyController.TransitionToState(baseEnemy.CreateEnemyPatrulState(enemyController, model, weapon));
        }
    }
}
