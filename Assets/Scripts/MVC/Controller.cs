using UnityEngine;

public abstract class Controller : MonoBehaviour 
{
    public Model model;
    public HealthBar healthBar;
    public BaseStats baseStats;
    public IHealthBar ihealthBar;

    private void Awake()
    {
        model = new PlayerModel(baseStats, healthBar);
    }

    public void ApplyHealing(float amount)
    {
        model.ApplyHealing(amount);
    }

    public void TakeDamage(float damage)
    {
        model.TakeDamage(damage);
    }
}
