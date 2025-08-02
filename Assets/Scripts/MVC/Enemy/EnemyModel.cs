using UnityEngine;

public class EnemyModel : Model
{
    public EnemyModel(EnemyStats baseStats) : base(baseStats)
    {
        stats = baseStats;
    }
}
