using UnityEngine;

public class MeleeWeapon : BaseWeapon
{
    private void OnTriggerEnter(Collider other)
    {
        if (isAttack &&(attackMask.LayerMask.value & (1 << other.gameObject.layer)) != 0)
        {
            if (other.TryGetComponent(out Controller controller))
            {
                DamageTrigger(controller, other.gameObject);
            }
        }
    }

    public virtual void DamageTrigger(Controller controller, GameObject attacker)
    {
        controller.TakeDamage(attackStats.Damage * damageMultiplier, attackStats.RepulsionForce * repulsionMultiplier, gameObject);
    }
}
