using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public BaseStats entityStats;
    public float HP = 100;
    private float fillAmountHP = 0;

    [Header("LerpSpeeds")]
    public float RedFillingSpeed = 0.4f; //скорость заполнения красной полоски
    public float RedDecreaseSpeed = 0.18f; //скорость уменьшения красной полоски
    public float YellowDecreaseSpeed = 1; //скорость уменьшения жёлтой полоски
    [Header("Image")]
    public Image redHP;
    public Image yellowHP;
    public Image greenHP;

    void Start()
    {
        redHP.fillAmount = HP / entityStats.MaxHP;
    }

    void Update()
    {
        fillAmountHP = HP / entityStats.MaxHP;

        float lerpTime = 0f;

        if (greenHP.fillAmount != redHP.fillAmount)
        {
            lerpTime += Time.deltaTime;
            redHP.fillAmount = Mathf.Lerp(redHP.fillAmount, fillAmountHP, redHP.fillAmount > greenHP.fillAmount ? lerpTime / RedDecreaseSpeed : lerpTime / RedFillingSpeed);
            yellowHP.fillAmount = Mathf.Lerp(yellowHP.fillAmount, fillAmountHP, yellowHP.fillAmount > redHP.fillAmount ? lerpTime / YellowDecreaseSpeed : 1);
        }

        if (Input.GetKeyUp(KeyCode.E)) //для проверки
        {
            ApplyHealing(10f);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            TakeDamage(10f);
        }
    }

    public virtual void TakeDamage(float damage)
    {
        if (HP - (damage * (100/(100 + entityStats.Armor))) <= 0)
        {
            HP = 0;
        }
        else
        {
            HP -= damage * (100 / (100 + entityStats.Armor));
        }
        greenHP.fillAmount = HP / entityStats.MaxHP;
    }

    public virtual void ApplyHealing(float amount)
    {
        if (HP + amount >= entityStats.MaxHP) 
        {
            HP = entityStats.MaxHP;
            greenHP.fillAmount = HP / entityStats.MaxHP;
            return;
        }
        HP += amount;
        greenHP.fillAmount = HP / entityStats.MaxHP;
    }
}
