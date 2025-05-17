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
    float HP { get; set; }
    float Armor {  get; set; }
}

public abstract class BaseStats : ScriptableObject, IHealthStats, IMoveSpeed, IAttackStats 
{
    [Header("Health")]
    [SerializeField] private float maxHP;
    [SerializeField] private float hp;
    [SerializeField] private float armor;
    [Header("Movement")]
    [SerializeField] private float speed;
    [Header("Attack")]
    [SerializeField] private float damage;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackSpeed;

    public float MaxHP
    {
        get { return maxHP; }
        set { maxHP = value; }
    }
    public float HP
    {
        get { return hp; }
        set { hp = value; }
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
}
