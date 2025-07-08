using UnityEngine;
using UnityEngine.Pool;

public class BulletPoolManager : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    private IObjectPool<Bullet> bulletPool;
    [SerializeField] private int defaultCapacity = 20;
    [SerializeField] private int maxSize = 100;

    public static BulletPoolManager Instance { get; private set; } 

    private void Awake()
    {
        Instance = this;

        bulletPool = new ObjectPool<Bullet>(CreateBullet, OnGetFromPool, OnReleaseToPool, OnDestroyPooledBullet, false, defaultCapacity, maxSize);
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

    private void OnDestroyPooledBullet(Bullet pooledBullet)
    {
        Destroy(pooledBullet.gameObject);
    }

    public Bullet GetBullet()
    {
        return bulletPool.Get();
    }

    public void ReleaseBullet(Bullet bullet)
    {
        bulletPool.Release(bullet);
    }
}
