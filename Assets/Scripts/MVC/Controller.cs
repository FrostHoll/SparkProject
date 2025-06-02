using UnityEngine;

public abstract class Controller : MonoBehaviour 
{
    protected Model model;
    protected View view;
    [SerializeField] protected BaseWeapon weapon;
    [SerializeField] protected Transform weaponSlot;
    [SerializeField] protected BaseStats baseStats;

    private void Awake()
    {
        view = GetComponent<View>();
    }

    public void ApplyHealing(float amount)
    {
        model.ApplyHealing(amount);
        view.healthBar.UpdateHealthBar(model.HP,model.stats.MaxHP);
    }

    public void TakeDamage(float damage)
    {
        model.TakeDamage(damage);
        view.healthBar.UpdateHealthBar(model.HP,model.stats.MaxHP);
    }

    public void AddWeapor(GameObject newWeapon) // пока что один слот оружия. Попозже подкручу больше
    {
        if(weapon == null)
        {
            GameObject WeponGameObject = Instantiate(newWeapon, weaponSlot);
            weapon = WeponGameObject.GetComponent<BaseWeapon>();
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

    public void Die() 
    {
        Destroy(gameObject);
    }
}
