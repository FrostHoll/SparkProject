using UnityEngine;

public class MeleeWeapon : BaseWeapon
{
    public LayerMask layerMask;
    public float damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (isAttack &&(layerMask.value & (1 << other.gameObject.layer)) != 0)
        {
            other.GetComponent<Controller>().TakeDamage(damage);
        }
    }

    public override void Attack(float damage, float range) 
    {
        
    }
}
