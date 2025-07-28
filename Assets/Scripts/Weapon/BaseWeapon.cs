using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [Header("Stats")]
    protected IAttackStats attackStats;
    protected float calculatedAttackSpeed;
    public float baseAttackTime = 1;
    [SerializeField] protected float bulletSpeed = 5;
    [Header("Multipliers")]
    [SerializeField] protected float damageMultiplier = 1;
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

    public void UpdateWeaponStats(BaseStats baseStats, float calculatedAttackSpeed)
    {
        attackStats = baseStats;
        attackMask = baseStats;
        this.calculatedAttackSpeed = calculatedAttackSpeed;
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

        bulletObject.Initialize(bulletSpeed, GetAtkStat(AtkStat.Damage), GetAtkStat(AtkStat.Range), GetAtkStat(AtkStat.Repulsion), attackMask);
        bulletObject.Deactivate();
    }

    public float GetAtkStat(AtkStat statName)
    {
        switch (statName)
        {
            case AtkStat.Damage:
                return attackStats.Damage * damageMultiplier;
            case AtkStat.Range:
                return attackStats.AttackRange * rangeMultiplier;
            case AtkStat.Repulsion:
                return attackStats.RepulsionForce * repulsionMultiplier;
            case AtkStat.AtkSpeed:
                return calculatedAttackSpeed;
        }
        Debug.Log("Такого стата нет");
        return 1f;
    }
}
