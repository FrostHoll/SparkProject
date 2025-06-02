using UnityEngine;

public class EnemyWizard : BaseEnemy
{
    public float teleportTime = 2f;
    private float timer = 0f;
    public bool isAttacking = false;

    public override void EnemyAI(EnemyMovement enemyMovement, Transform player, View view, Model model, BaseWeapon weapon = null)
    {
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
}
