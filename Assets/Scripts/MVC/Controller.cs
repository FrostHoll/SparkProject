using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour 
{
    protected Model model;
    protected View view;
    [SerializeField] protected BaseWeapon weapon;
    [SerializeField] protected Transform weaponSlot;
    public Repulsiveness repulsiveness;

    protected List<Artifact> ActiveArtifacts = new();

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

    public void AddWeapon(BaseWeapon newWeapon) 
    {
        if(weapon == null)
        {
            BaseWeapon weaponInstance = Instantiate(newWeapon, weaponSlot);
            model.InitializeCurrentWeaponAttackSpeed(newWeapon.baseAttackTime);
            weapon = weaponInstance;
            weapon.UpdateWeaponStats(model.stats, model.calculatedAttackSpeed);
            model.AttackSpeedCalculate();
            view.AttackSpeedAnimChanged(model.calculatedAttackSpeed);
        }
    }
    public void RemoveWeapon()
    {
        if (weapon != null)
        {
            Destroy(weapon.gameObject);
            weapon = null;
            model.InitializeCurrentWeaponAttackSpeed(1);
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

    public abstract void SetSide(IAttackMask masks = null, string controllerTag = null, int layerIndex = 0);

    public abstract void Die();
}
