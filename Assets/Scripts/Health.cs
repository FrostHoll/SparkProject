using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float MaxHP = 100f;
    public float HP = 100;
    private float fillAmountHP = 0;

    [Header("LerpSpeeds")]
    public float lerpSpeedRed = 0.4f;
    public float reducedSpeedRed = 0.18f;
    public float lerpSpeedYellow = 1;
    [Header("Image")]
    public Image redHP;
    public Image yellowHP;
    public Image greenHP;

    void Start()
    {
        redHP.fillAmount = HP / MaxHP;
    }

    void Update()
    {
        fillAmountHP = HP / MaxHP;

        float lerpTime = 0f;

        if (greenHP.fillAmount != redHP.fillAmount)
        {
            lerpTime += Time.deltaTime;
            redHP.fillAmount = Mathf.Lerp(redHP.fillAmount, fillAmountHP, redHP.fillAmount > greenHP.fillAmount ? lerpTime / reducedSpeedRed : lerpTime / lerpSpeedRed);
            yellowHP.fillAmount = Mathf.Lerp(yellowHP.fillAmount, fillAmountHP, yellowHP.fillAmount > redHP.fillAmount ? lerpTime / lerpSpeedYellow : 1);
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
        HP -= damage;
        greenHP.fillAmount = HP / MaxHP;
    }

    public virtual void ApplyHealing(float amount)
    {
        if (HP + amount >= MaxHP) 
        {
            HP = MaxHP;
            greenHP.fillAmount = HP / MaxHP;
            return;
        }
        HP += amount;
        greenHP.fillAmount = HP / MaxHP;
    }
}
