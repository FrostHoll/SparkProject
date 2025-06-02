using UnityEngine;

public class Bullet : MonoBehaviour 
{
    public float speed;
    public float lifeTime = 2.5f;
    public LayerMask layerMask;
    public float damage = 0;

    void Update()
    {
        BaseBullet();
    }

    protected virtual void BaseBullet()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
            return;
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) //надо будет доделать (пролетает стены)
    {
        if ((layerMask.value & (1 << other.gameObject.layer)) != 0)
        {
            other.GetComponent<Controller>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
