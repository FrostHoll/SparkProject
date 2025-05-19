using System;

public abstract class Model
{
    public BaseStats stats;
    public float HP;
    public event Action<float, float> HealthChanged;

    public Model(BaseStats baseStats)
    {
        stats = baseStats;
        HP = stats.MaxHP;
    }

    public virtual void TakeDamage(float damage)
    {
        if (HP - (damage * (100 / (100 + stats.Armor))) <= 0)
        {
            HP = 0;
        }
        else
        {
            HP -= damage * (100 / (100 + stats.Armor));
        }
        HealthChanged?.Invoke(HP, stats.MaxHP);
    }

    public void ApplyHealing(float amount)
    {
        if (HP + amount >= stats.MaxHP)
        {
            HP = stats.MaxHP;
        }
        else
        {
            HP += amount;
        }
        HealthChanged?.Invoke(HP, stats.MaxHP);
    }
}
