using System;

public abstract class Model
{
    public BaseStats stats;
    public float HP;
    public float calculatedAttackSpeed;
    private float currentAttackAnim = 1;

    public event Action<float, float> HealthChanged;
    public AmplifiersWrapper Amplifiers { get; } = new();

    public Model(BaseStats baseStats)
    {
        stats = baseStats;
        HP = stats.MaxHP;
        AttackSpeedCalculate();
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

    public void ApplyAmp(Amplifier amp)
    {
        Amplifiers.AddAmplifier(amp);
        RecalculateStats();
    }

    public void RemoveAmp(Amplifier amp)
    {
        Amplifiers.RemoveAmplifier(amp);
        RecalculateStats();
    }

    public void AttackSpeedCalculate()
    {
        calculatedAttackSpeed = stats.AttackSpeed / (100 * currentAttackAnim);
        calculatedAttackSpeed = Math.Clamp(calculatedAttackSpeed, 0.1f, 6); //min и max значения 0.1 и 6
    }

    public void InitializeCurrentWeaponAttackSpeed(float attackSpeed)
    {
        currentAttackAnim = attackSpeed;
        AttackSpeedCalculate();
    }

    private void RecalculateStats() 
    {
        stats.Damage = Amplifiers.GetModifiedValue(StatType.Damage, stats.Damage);
        stats.MaxHP = Amplifiers.GetModifiedValue(StatType.MaxHP, stats.MaxHP);
        stats.AttackRange = Amplifiers.GetModifiedValue(StatType.AttackRange, stats.AttackRange);
        stats.AttackSpeed = Amplifiers.GetModifiedValue(StatType.AttackSpeed, stats.AttackSpeed);
        stats.Armor = Amplifiers.GetModifiedValue(StatType.Armor, stats.Armor);

        AttackSpeedCalculate();
    }
} 
 