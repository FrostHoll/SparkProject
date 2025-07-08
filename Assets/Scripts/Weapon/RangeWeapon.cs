using UnityEngine;
using UnityEngine.Pool;

public class RangeWeapon : BaseWeapon
{
    private void Update()
    {
        if (isAttack && Time.time >= timer)
        {
            Attack(attackStats.Damage, attackStats.AttackRange);
            timer = Time.time + attackStats.AttackSpeed * attackSpeedMultiplier;
        }
    }
}
