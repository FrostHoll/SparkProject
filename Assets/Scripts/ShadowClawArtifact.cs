using static UnityEngine.GraphicsBuffer;

public class ShadowClawArtifact : Artifact
{
    public override string ArtifactName => "Shadow Claw";
    float effect = 0.1f;

    public override void ApplyEffect(Controller player)
    {
        CurrentAmplifier = new Amplifier(StatType.Damage, effect, false);
        player.ApplyAmp(CurrentAmplifier.Value);
    }

    public override void RemoveEffect(Controller player)
    {
        if (CurrentAmplifier.HasValue)
            player.RemoveAmp(CurrentAmplifier.Value);

    }

    public override Artifact Clone() => new ShadowClawArtifact();
}