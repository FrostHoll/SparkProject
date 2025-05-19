using UnityEngine;

public class EnemyHealth : Health 
{
    [SerializeField] private GameObject enemyCanvas;

    public override void TakeDamage(float damage)
    {
        enemyCanvas.SetActive(true);
        base.TakeDamage(damage);
        if (HP <= 0) Destroy(gameObject);
    }
    public override void ApplyHealing(float amount)
    {
        base.ApplyHealing(amount);
        if (HP >= entityStats.MaxHP) enemyCanvas.SetActive(false);
    }
}
