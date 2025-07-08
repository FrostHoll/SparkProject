using UnityEngine;

public interface IAttackStats
{
    float Damage { get; set; }
    float AttackRange { get; set; }
    float AttackSpeed { get; set; }
}

public interface IHealthStats
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
    [SerializeField] private float maxHP;
    [SerializeField] private float armor;
    [Header("Movement")]
    [SerializeField] private float speed;
    [Header("Attack")]
    [SerializeField] private float damage;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackSpeed;
    [Header("AttackMask")]
    private LayerMask layerMask;
    private LayerMask ignoreMask;

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

    public BaseStats CloneForRuntime()
    {
        var copy = CreateInstance<BaseStats>();
        copy.maxHP = maxHP;
        copy.armor = armor;
        copy.speed = speed;
        copy.damage = damage;
        copy.attackRange = attackRange;
        copy.attackSpeed = attackSpeed;
        return copy;

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
