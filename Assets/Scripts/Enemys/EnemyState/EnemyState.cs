using UnityEngine;

public abstract class EnemyState 
{
    protected EnemyController enemyController;
    protected EnemyMovement enemyMovement;
    protected Transform player;
    protected View view;
    protected Model model;
    protected BaseWeapon weapon; 
    protected EnemyBaseAI baseEnemy;

    public EnemyState(EnemyController enemyController, Model enemyModel, BaseWeapon baseWeapon)
    {
        this.enemyController = enemyController;
        enemyMovement = enemyController.GetComponent<EnemyMovement>();
        player = enemyController.player;
        view = enemyController.GetComponent<EnemyView>();
        model = enemyModel;
        weapon = baseWeapon; 
        baseEnemy = enemyController.GetComponent<EnemyBaseAI>();
    }

    public abstract void StateExecute();
}
