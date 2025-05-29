using UnityEngine;

public abstract class Artifact : MonoBehaviour
{
    public abstract string ArtifactName { get; }
    public Sprite Icon;
    public AmplifiersWrapper Amplifiers;

    protected Controller _owner;

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
