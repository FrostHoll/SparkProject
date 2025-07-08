using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [Header("Stats")]
    protected IAttackStats attackStats;
    [SerializeField] protected float bulletSpeed = 5;
    [Header("Multipliers")]
    [SerializeField] protected float damageMultiplier = 1;
    [SerializeField] protected float attackSpeedMultiplier = 1;
    [SerializeField] protected float rangeMultiplier = 1;
    [SerializeField] protected float repulsionMultiplier = 1;

    [Header("Other")]
    protected float timer = 0;
    [SerializeField] private Transform attackPoint;
    protected IAttackMask attackMask;
    public bool isAttack = false;

    public virtual void StartOrStopAttack(bool canAttack)
    {
        isAttack = canAttack;
    }

    public void AddStats(BaseStats baseStats)
    {
        this.attackStats = baseStats;
        this.attackMask = baseStats;
    }

    public void Shooting(float damage, float range, float repulsionForce)
    {
        Bullet bulletObject = BulletPoolManager.Instance.GetBullet(); 

        if (bulletObject == null)
        {
            return;
        }

        Quaternion yRotation = Quaternion.Euler(0f, attackPoint.rotation.eulerAngles.y, 0f);
        bulletObject.transform.SetPositionAndRotation(attackPoint.position, yRotation);

        bulletObject.Initialize(bulletSpeed, damage * damageMultiplier, range * rangeMultiplier, repulsionForce * repulsionMultiplier, attackMask);
        bulletObject.Deactivate();
    }
}
