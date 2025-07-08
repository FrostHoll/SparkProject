using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour 
{
    public float speed; //скорость пули зависит от оружия
    public float lifeTime = 2.5f;
    public IAttackMask attackMask;
    public float damage;
    public float repulsionForce;

    private IObjectPool<Bullet> bulletPool;

    public IObjectPool<Bullet> BulletPool { set => bulletPool = value; }

    public void Initialize(float bulletSpeed, float bulletDamage, float bulletLifeTime, float repulsionForce, IAttackMask mask) 
    {
        speed = bulletSpeed;
        damage = bulletDamage;
        lifeTime = bulletLifeTime;
        this.repulsionForce = repulsionForce;
        attackMask = mask;
    }

    public void Deactivate()
    {
        StartCoroutine(DeactivateRoutine(lifeTime));
    }
    IEnumerator DeactivateRoutine(float lifeTime) 
    {
        yield return new WaitForSeconds(lifeTime);

        bulletPool.Release(this);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (attackMask.IgnoreMask == (attackMask.IgnoreMask | (1 << other.gameObject.layer))) //проверка на слои которые нужно игнорировать
        {
            return; 
        }
        if (attackMask.LayerMask == (attackMask.LayerMask | (1 << other.gameObject.layer))) //если наткнулся на то чему нужно наносить урон
        {
            if (other.TryGetComponent(out Controller controller))
            {
                controller.TakeDamage(damage, repulsionForce, gameObject);
            }
            bulletPool.Release(this);
        }
        else //если наткнулся на просто обьект 
        {
            bulletPool.Release(this);
        }
    }
}
