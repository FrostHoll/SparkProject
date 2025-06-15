using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour //его дочерние классы отвечают за определение поведения врага.
{     //проще говоря если накинуть на врага с палкой вместо EnemyWithStick закинуть EnemyWizard то враг будет вести себя как маг а не как враг с палкой
    public abstract EnemyState CreateEnemyAttackState(EnemyController enemyController, Model enemyModel, BaseWeapon baseWeapon);

    public EnemyState CreateEnemyPatrulState(EnemyController enemyController, Model enemyModel, BaseWeapon baseWeapon) //состояние патруля у всех одинаковое 
                                                                                                                       //при надобности это можно будет изменить
    {
        return new PatrolStat(enemyController,enemyModel,baseWeapon);
    }
}
