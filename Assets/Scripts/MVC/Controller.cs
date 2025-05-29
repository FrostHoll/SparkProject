using System.Linq.Expressions;
using UnityEngine;

public abstract class Controller : MonoBehaviour 
{
    protected Model model;
    protected View view;
    [SerializeField] protected BaseStats baseStats;

    private void Awake()
    {
        view = GetComponent<View>();
    }

    public void ApplyHealing(float amount)
    {
        model.ApplyHealing(amount);
        view.UpdateHealthBar(model.HP,model.stats.MaxHP);
    }

    public void TakeDamage(float damage)
    {
        model.TakeDamage(damage);
        view.UpdateHealthBar(model.HP,model.stats.MaxHP);
    }

    public void ApplyAmp(StatType type, float value)
    {
        model.ApplyAmp(type, value);
    }
}
