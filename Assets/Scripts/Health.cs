using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float MaxHP = 100f;
    public float HP = 100;
    public float learpSpeed = 0.05f;
    [Header("Sliders")]
    public Slider HP_Slider;
    public Slider easeHealthBar;
    void Start()
    {
        HP_Slider.maxValue = MaxHP;
        easeHealthBar.maxValue = MaxHP;
        HP_Slider.value = MaxHP;
    }

    void Update()
    {

        if (HP_Slider.value != easeHealthBar.value) 
        {
            easeHealthBar.value = Mathf.Lerp(easeHealthBar.value, HP,easeHealthBar.value > HP ? learpSpeed : 1);
        }

        if (Input.GetKeyUp(KeyCode.E)) //для проверки
        {
            Hieal(10f);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            TakeDamage(10f);
        }
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
        HP_Slider.value = HP;
    }

    public void Hieal(float heal)
    {
        if (HP + heal >= MaxHP) 
        {
            HP = MaxHP;
            HP_Slider.value = HP;
            return;
        }
        HP += heal;
        HP_Slider.value = HP;
    }

}
