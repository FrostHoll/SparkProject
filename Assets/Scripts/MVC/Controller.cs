using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public abstract class Controller : MonoBehaviour 
{
    protected Model model;
    protected View view;
    [SerializeField] protected BaseStats baseStats;

    protected List<Artifact> ActiveArtifacts = new();

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
}
