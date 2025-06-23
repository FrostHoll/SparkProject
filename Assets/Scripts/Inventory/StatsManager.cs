using UnityEditor.Experimental;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public PlayerController characterController;
    public EnemyController enemyController;

    public void CharacterAddArtifact(Artifact artifact)
    {
        if (artifact == null) return;

        artifact.ApplyEffect(characterController);
    }

    public void EnemyAddArtifact(Artifact artifact)
    {
        if (artifact == null) return;

        artifact.ApplyEffect(enemyController);
    }
}
