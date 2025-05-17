using UnityEngine;

public class Health : MonoBehaviour
{
    public BaseStats baseStats;
    public float HP = 100;
    private HealthBar healthBar;

    void Start()
    {
        healthBar = GetComponent<HealthBar>();
        healthBar.UpdateHealthBar(HP,baseStats.MaxHP);
    }

    void Update()
    {
        healthBar.HealthBarRenderer(HP, baseStats.MaxHP);

        if (Input.GetKeyUp(KeyCode.E)) //для проверки
        {
            ApplyHealing(10f);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            TakeDamage(10f);
        }
    }

    public void TakeDamage(float damage)
    {
        if (HP - (damage * (100/(100 + baseStats.Armor))) <= 0)
        {
            HP = 0;
        }
        else
        {
            HP -= damage * (100 / (100 + baseStats.Armor));
        }
        healthBar.UpdateHealthBar(HP, baseStats.MaxHP);

    }

    public void ApplyHealing(float amount)
    {
        if (HP + amount >= baseStats.MaxHP) 
        {
            HP = baseStats.MaxHP;
        }
        else
        {
            HP += amount;
        }
        healthBar.UpdateHealthBar(HP, baseStats.MaxHP);
    }
}
