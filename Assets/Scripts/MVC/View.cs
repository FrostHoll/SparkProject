using UnityEngine;

public abstract class View : MonoBehaviour
{
    public Animator animator;
    public HealthBar healthBar;

    private float currentHP = 0; 
    private float maxHP = 0;

    public void OnHealthChanged(float hp, float maxHP)
    {
        currentHP = hp;
        this.maxHP = maxHP;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (healthBar.greenHP.fillAmount != healthBar.yellowHP.fillAmount || healthBar.redHP.fillAmount != healthBar.greenHP.fillAmount)
        {
            healthBar.HealthBarRenderer(currentHP, maxHP);
        }
    }

    public void ChangeAttackAnim(bool isAttacking)
    {
        animator.SetBool("CanAttack", isAttacking);
    }
}
