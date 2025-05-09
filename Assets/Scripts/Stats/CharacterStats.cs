using UnityEngine;

[CreateAssetMenu]
public class CharacterStats : BaseStats, IDash
{
    [Header("Dash")]
    [SerializeField] float timeOfDash;
    [SerializeField] float dashIncreaseSpeed;
    public float TimeOfDash 
    {
        get { return timeOfDash; }
        set { timeOfDash = value; }
    }
    public float DashIncreaseSpeed
    {
        get { return dashIncreaseSpeed; }
        set { dashIncreaseSpeed = value; }
    }
}
