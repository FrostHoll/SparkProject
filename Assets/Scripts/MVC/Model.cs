using System;
using Unity.VisualScripting;
using UnityEngine.Rendering;

public abstract class Model
{
    public BaseStats stats;
    public float HP;

    public BaseStats CurrentStats { get; }

    public event Action<float, float> HealthChanged;
    public AmplifiersWrapper Amplifiers { get; } = new();

    public Model(BaseStats baseStats)
    {
        stats = baseStats;
        HP = stats.MaxHP;
        CurrentStats = baseStats.CloneForRuntime();
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

    private void RecalculateStats() //пересчёт всех статов
    {
        CurrentStats.Damage = Amplifiers.GetModifiedValue(StatType.Damage, stats.Damage);
        CurrentStats.MaxHP = Amplifiers.GetModifiedValue(StatType.MaxHP, stats.MaxHP);
        CurrentStats.AttackRange = Amplifiers.GetModifiedValue(StatType.AttackRange, stats.AttackRange);
        CurrentStats.AttackSpeed = Amplifiers.GetModifiedValue(StatType.AttackSpeed, stats.AttackSpeed);
        CurrentStats.Armor = Amplifiers.GetModifiedValue(StatType.Armor, stats.Armor);
    }
} 
