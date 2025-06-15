using UnityEngine;

public class EnemyWithStick : BaseEnemy
{
    public override EnemyState CreateEnemyAttackState(EnemyController enemyController, Model enemyModel, BaseWeapon baseWeapon)
    {
        return new EnemyMeleeAttackState(enemyController, enemyModel, baseWeapon);
    }
}
