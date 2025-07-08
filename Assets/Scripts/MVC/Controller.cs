using UnityEngine;

public abstract class Controller : MonoBehaviour 
{
    protected Model model;
    protected View view;
    [SerializeField] protected BaseWeapon weapon;
    [SerializeField] protected Transform weaponSlot;
    [SerializeField] protected BaseStats baseStats;
    public Repulsiveness repulsiveness;

    protected virtual void Awake()
    {
        view = GetComponent<View>();
    }

    protected virtual void Update()
    {
        if (model.HP <= 0)
        {
            Die();
        }
    }

    public void ApplyHealing(float amount)
    {
        model.ApplyHealing(amount);
        view.healthBar.UpdateHealthBar(model.HP,model.stats.MaxHP);
    }

    public void TakeDamage(float damage, float repulsionForce = 0, GameObject source = null)
    {
        model.TakeDamage(damage);
        view.healthBar.UpdateHealthBar(model.HP,model.stats.MaxHP);

        if (source != null && repulsiveness != null)
        {
            repulsiveness.ApplyRepulsion(source, repulsionForce);
        }
    }

    public void AddWeapor(BaseWeapon newWeapon) 
    {
        if(weapon == null)
        {
            BaseWeapon weaponInstance = Instantiate(newWeapon, weaponSlot); 
            weapon = weaponInstance;
            weapon.AddStats(baseStats);
        }
    }

    public void RemoveWeapon()
    {
        if (weapon != null)
        {
            Destroy(weapon.gameObject);
            weapon = null;
        }
    }

    public abstract void Die();

}
