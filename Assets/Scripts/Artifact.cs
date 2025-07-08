using UnityEngine;

public abstract class Artifact
{
    public abstract string ArtifactName { get; }
    public Sprite Icon;

    protected Controller _owner;

    protected Amplifier? CurrentAmplifier;

    public virtual void ApplyEffect(Controller player)
    {
        _owner = player;
    }

    public virtual void RemoveEffect(Controller player)
    {
        _owner = player;
    }

    public abstract Artifact Clone();
}
