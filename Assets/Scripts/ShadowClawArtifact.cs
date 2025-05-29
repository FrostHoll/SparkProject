public class ShadowClawArtifact : Artifact
{
    public override string ArtifactName => "Shadow Claw";
    float effect = 0.1f;

    public override void ApplyEffect(Controller player)
    {
        Amplifiers.AddAmplifier(  StatType.Damage, effect, false );
        player.ApplyAmp(StatType.Damage, effect);
    }

    public override void RemoveEffect(Controller player)
    {
        Amplifiers.RemoveAmplifier(StatType.Damage, effect, false );
        
    }

    public override Artifact Clone()
    {
        return new ShadowClawArtifact();
    }
}