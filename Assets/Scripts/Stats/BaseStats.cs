using UnityEngine;

public interface IAttackSpeed
{
    float AttackSpeed { get; set; }
}

public interface IAttackStats : IAttackSpeed
{
    float Damage { get; set; }
    float AttackRange { get; set; }
    float RepulsionForce { get; set; }
}

public interface IRepulsionResistance
{
    float RepulsionResistance { get; set; }
}

public interface IHealthStats : IRepulsionResistance
{
    float MaxHP { get; set; }
    float Armor {  get; set; }
}

public interface IAttackMask
{
    LayerMask LayerMask { get; set; } //чему должна наносить урон
    LayerMask IgnoreMask { get; set; } //что должна игнорировать
}

public abstract class BaseStats : ScriptableObject, IHealthStats, IMoveSpeed, IAttackStats, IAttackMask
{
    [Header("Health")]
    [SerializeField] protected float maxHP;
    [SerializeField] protected float armor;
    [SerializeField] protected float repulsionResistance;
    [Header("Movement")]
    [SerializeField] protected float speed;
    [Header("Attack")]
    [SerializeField] protected float damage;
    [SerializeField] protected float attackRange;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float repulsionForce = 4f;
    [Header("AttackMask")]
    [SerializeField] protected LayerMask layerMask;
    [SerializeField] protected LayerMask ignoreMask;

    public float MaxHP
    {
        get { return maxHP; }
        set { maxHP = value; }
    }
    public float Armor
    {
        get { return armor; }
        set { armor = value; }
    }
    public float RepulsionResistance
    {
        get { return repulsionResistance; }
        set { repulsionResistance = value; }
    }
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    public float AttackRange
    {
        get { return attackRange; }
        set { attackRange = value; }
    }
    public float AttackSpeed
    {
        get { return attackSpeed; }
        set { attackSpeed = value; }
    }

    public float RepulsionForce
    {
        get { return repulsionForce; }
        set { repulsionForce = value; }
    }

    public LayerMask LayerMask
    {
        get { return layerMask; }
        set { layerMask = value; }
    }

    public LayerMask IgnoreMask
    {
        get { return ignoreMask; }
        set { ignoreMask = value; }
    }
}
