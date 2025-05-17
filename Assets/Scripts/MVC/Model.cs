
public abstract class Model
{
    private IHealthBar view;
    private IHealthStats healthStats;

    public Model(IHealthStats ihealthStats, IHealthBar view)
    {
        this.view = view;
        healthStats = ihealthStats;
    }

    public virtual void TakeDamage(float damage)
    {
        if (healthStats.HP - (damage * (100 / (100 + healthStats.Armor))) <= 0)
        {
            healthStats.HP = 0;
        }
        else
        {
            healthStats.HP -= damage * (100 / (100 + healthStats.Armor));
        }
        view.UpdateHealthBar(healthStats.HP, healthStats.MaxHP);
    }

    public void ApplyHealing(float amount)
    {
        if (healthStats.HP + amount >= healthStats.MaxHP)
        {
            healthStats.HP = healthStats.MaxHP;
        }
        else
        {
            healthStats.HP += amount;
        }
        view.UpdateHealthBar(healthStats.HP, healthStats.MaxHP);
    }
}
