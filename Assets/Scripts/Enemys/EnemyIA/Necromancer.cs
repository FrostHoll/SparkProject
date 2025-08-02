using UnityEngine;

public class Necromancer : EnemyBaseAI
{
    public override EnemyState CreateEnemyAttackState(EnemyController enemyController, Model enemyModel, BaseWeapon baseWeapon)
    {
        return new EnemyMeleeAttackState(enemyController, enemyModel, baseWeapon);
    }
}
