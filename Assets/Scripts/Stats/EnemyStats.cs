using UnityEngine;

public interface IEnemyStats
{
    float AgrRadius { get; set; }
}

[CreateAssetMenu]
public class EnemyStats : BaseStats, IEnemyStats
{
    [Header("Enemy")]
    [SerializeField] private float agrRadius;
    public float AgrRadius
    {
        get { return agrRadius; }
        set { agrRadius = value; }
    }
}
