using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public abstract class Controller : MonoBehaviour 
{
    protected Model model;
    protected View view;
    [SerializeField] protected BaseWeapon weapon;
    [SerializeField] protected Transform weaponSlot;
    [SerializeField] protected BaseStats baseStats;

    protected List<Artifact> ActiveArtifacts = new();

    private void Awake()
    {
        view = GetComponent<View>();
        weapon.attackStats = baseStats;
    }

    protected virtual void Start()
    {
        if(weapon != null) weapon.attackStats = model.stats;
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

    public void TakeDamage(float damage)
    {
        model.TakeDamage(damage);
        view.healthBar.UpdateHealthBar(model.HP,model.stats.MaxHP);
    }

    public void AddWeapor(GameObject newWeapon) // пока что один слот оружия. 
    {
        if(weapon == null)
        {
            GameObject WeponGameObject = Instantiate(newWeapon, weaponSlot);
            weapon = WeponGameObject.GetComponent<BaseWeapon>();
            weapon.attackStats = model.stats;
            weapon.attackMask = model.stats;
        }
    }


    public void ApplyAmp(Amplifier amp) => model.ApplyAmp(amp);
    public void RemoveAmp(Amplifier amp) => model.RemoveAmp(amp);

    public void AddArtifact(Artifact artifact)
    {
        ActiveArtifacts.Add(artifact);
        artifact.ApplyEffect(this);
    }

    public void RemoveArtifact(Artifact artifact)
    {
        if (ActiveArtifacts.Remove(artifact))
        {
            artifact.RemoveEffect(this);
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
