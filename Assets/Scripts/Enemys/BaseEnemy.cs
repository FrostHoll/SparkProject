using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    public abstract void EnemyAI(EnemyMovement enemyMovement, Transform player, View view, Model model, BaseWeapon weapon = null);
}
