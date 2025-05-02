using UnityEngine;

public class VremenBulet : MonoBehaviour // временная пуля. Хотел посматреть как будет выглядить
{
    public float speed;
    public float lifeTime = 2.5f;

    void Update()
    {
        BaseBulet();
    }

    protected virtual void BaseBulet()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
            return;
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

}
