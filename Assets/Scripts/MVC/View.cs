using UnityEngine;

public abstract class View : MonoBehaviour
{
    public Animator animator;
    public HealthBar healthBar;

    private float currentHP = 100;
    private float maxHP = 100;

    public virtual void OnHealthChanged(float hp, float maxHP)
    {
        currentHP = hp;
        this.maxHP = maxHP;
    }

    public virtual void AttackSpeedAnimChanged(float speed)
    {
        animator.SetFloat("AttackSpeed", speed);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        healthBar = GetComponent<HealthBar>();
    }

    public void Update()
    {
        healthBar.HealthBarRenderer(currentHP, maxHP);
    }

    public void StopAttackAnim()
    {
        animator.SetBool("CanAttack", false);
    }

    public void StartAttackAnim()
    {
        animator.SetBool("CanAttack", true);
    }
}
