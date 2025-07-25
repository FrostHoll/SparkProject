using UnityEngine;

public class StarJelly : BaseEnemy
{
    public override EnemyState CreateEnemyAttackState(EnemyController enemyController, Model enemyModel, BaseWeapon baseWeapon)
    {
        return new GravityCrushAttackState(enemyController, enemyModel, baseWeapon);
    }
}
