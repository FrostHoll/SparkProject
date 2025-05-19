using System;

public abstract class Model
{
    private IHealthStats healthStats;
    public float HP;
    public event Action<float, float> HealthChanged;

    public Model(IHealthStats healthStatsInterfac)
    {
        healthStats = healthStatsInterfac;
        HP = healthStats.MaxHP;
    }

    public virtual void TakeDamage(float damage)
    {
        if (HP - (damage * (100 / (100 + healthStats.Armor))) <= 0)
        {
            HP = 0;
        }
        else
        {
            HP -= damage * (100 / (100 + healthStats.Armor));
        }
        HealthChanged?.Invoke(HP, healthStats.MaxHP);
    }

    public void ApplyHealing(float amount)
    {
        if (HP + amount >= healthStats.MaxHP)
        {
            HP = healthStats.MaxHP;
        }
        else
        {
            HP += amount;
        }
        HealthChanged?.Invoke(HP, healthStats.MaxHP);
    }
}
