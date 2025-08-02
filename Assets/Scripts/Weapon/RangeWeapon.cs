using UnityEngine;

public class RangeWeapon : BaseWeapon
{
    private void Update()
    {
        if (isAttack && Time.time >= timer)
        {
            RangeAttack();
            timer = Time.time + (1 / calculatedAttackSpeed);
        }
    }

    public virtual void RangeAttack()
    {
        Shooting(attackStats.Damage, attackStats.AttackRange, attackStats.RepulsionForce);
    }
}
