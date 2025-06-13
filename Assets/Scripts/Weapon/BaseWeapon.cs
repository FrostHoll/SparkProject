using UnityEngine;
using UnityEngine.Pool;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField] public float bulletSpeed = 5;
    protected float timer = 0;
    [SerializeField] private Transform attackPoint;
    public IAttackStats attackStats;
    public IAttackMask attackMask;
    public bool isAttack = false;

    [Header("ObjectPool")]
    [SerializeField] private Bullet bulletPrefab;
    private IObjectPool<Bullet> bulletPool;
    [SerializeField] private int defaultCapacity = 20; 
    [SerializeField] private int maxSize = 100;
    [Header("Multipliers")]
    [SerializeField] protected float damageMultiplier = 1;
    [SerializeField] protected float attackSpeedMultiplier = 1;
    [SerializeField] protected float rangeMultiplier = 1;

    private void Awake()
    {
        bulletPool = new ObjectPool<Bullet>(CreateBullet,OnGetFromPool,OnReleaseToPool,OnDestroyPooledBullet, false ,defaultCapacity,maxSize);
    }

    private Bullet CreateBullet()
    {
        Bullet bulletInstantiate = Instantiate(bulletPrefab);
        bulletInstantiate.BulletPool = bulletPool;
        return bulletInstantiate;
    }

    private void OnGetFromPool(Bullet pooledBullet)
    {
        pooledBullet.gameObject.SetActive(true);
    }

    private void OnReleaseToPool(Bullet pooledBullet)
    {
        pooledBullet.gameObject.SetActive(false);
    }

    private void OnDestroyPooledBullet(Bullet pooledBullet) //если пуль будет больше maxSize то они уничтожаться после исполнения своих обязонностей
    {
        Destroy(pooledBullet.gameObject);
    }

    public virtual void StartOrStopAttack(bool canAttack)
    {
        isAttack = canAttack;
    }

    public void Attack(float damage,float range) 
    {
        Bullet bulletObject = bulletPool.Get();

        if (bulletObject == null)
        {
            return;
        }

        Quaternion yRotation = Quaternion.Euler(0f, attackPoint.rotation.eulerAngles.y, 0f);
        bulletObject.transform.SetPositionAndRotation(attackPoint.position,yRotation);

        bulletObject.Deactivate();

        bulletObject.damage = damage * damageMultiplier;
        bulletObject.lifeTime = range * rangeMultiplier;
        bulletObject.speed = bulletSpeed;
        bulletObject.attackMask = attackMask;
        
    }
}
