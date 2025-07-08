using UnityEngine;

public class RangeWeapon : BaseWeapon
{
    private void Update()
    {
        if (isAttack && Time.time >= timer)
        {
            Shooting(attackStats.Damage, attackStats.AttackRange, attackStats.RepulsionForce);
            timer = Time.time + attackStats.AttackSpeed * attackSpeedMultiplier;
        }
    }
}
