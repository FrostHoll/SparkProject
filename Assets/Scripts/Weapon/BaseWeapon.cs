using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    public bool isAttack = false;
    public float timer = 0;
    public float attackTime = 1;

    public virtual void StartOrStopAttack(bool canAttack)
    {
        isAttack = canAttack;
    }

    
    public abstract void Attack(float damage,float range);
}
