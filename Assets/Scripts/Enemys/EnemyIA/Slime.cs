using UnityEngine;

public class Slime : EnemyBaseAI
{
    public override EnemyState CreateEnemyAttackState(EnemyController enemyController, Model enemyModel, BaseWeapon baseWeapon)
    {
        return new SlimeAttackState(enemyController, enemyModel, baseWeapon);
    }
}
