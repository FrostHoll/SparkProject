using UnityEngine;

public class RangeWeapon : BaseWeapon
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform attackPoint;

    private void Update()
    {
        if (isAttack && Time.time >= timer)
        {
            Attack(20, 20);
            timer = Time.time + attackTime;
        }
    }

    public override void Attack(float damage, float range) //надо будет переделать (стреляет криво) и сделать обжект пул 
    {
        Quaternion yRotation = Quaternion.Euler(0f, attackPoint.rotation.eulerAngles.y, 0f);
        GameObject weapoBullet = Instantiate(bullet, attackPoint.position, yRotation);
        weapoBullet.GetComponent<Bullet>().damage = damage;
    }
}
