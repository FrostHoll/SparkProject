using UnityEngine;

public class Undead : EnemyBaseAI
{
    public override EnemyState CreateEnemyAttackState(EnemyController enemyController, Model enemyModel, BaseWeapon baseWeapon)
    {
        return new UndeadAttack(enemyController, enemyModel, baseWeapon);
    }
}
