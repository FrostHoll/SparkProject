using UnityEngine;

public class EnemyWizard : BaseEnemy 
{
    public override EnemyState CreateEnemyAttackState(EnemyController enemyController, Model enemyModel, BaseWeapon baseWeapon)
    {
        return new WizardRangeAttackState(enemyController, enemyModel, baseWeapon);
    }
}
