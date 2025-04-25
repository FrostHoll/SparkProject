using UnityEngine;

public class EnemyHealth : Health
{
    private GameObject enemyCanvas;

    private void Start()
    {
        enemyCanvas = GetComponentInChildren<Canvas>().gameObject;
        enemyCanvas.SetActive(false);
    }
    public override void TakeDamage(float damage)
    {
        enemyCanvas.SetActive(true);
        base.TakeDamage(damage);
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
    public override void Hiealing(float healingAmount)
    {
        if (HP + healingAmount >= MaxHP)
        {
            HP = MaxHP;
            Green_HP.fillAmount = HP / MaxHP;
            enemyCanvas.SetActive(false);
            return;
        }
        HP += healingAmount;
        Green_HP.fillAmount = HP / MaxHP;
    }
}
