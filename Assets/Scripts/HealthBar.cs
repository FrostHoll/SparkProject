using UnityEngine;
using UnityEngine.UI;

public interface IHealthBar
{
    void UpdateHealthBar(float hp, float maxHP);
}

public class HealthBar : MonoBehaviour
{
    private float fillAmountHP = 0;

    [Header("LerpSpeeds")]
    public float RedFillingSpeed = 0.4f; //скорость заполнения красной полоски
    public float RedDecreaseSpeed = 0.18f; //скорость уменьшения красной полоски
    public float YellowDecreaseSpeed = 1; //скорость уменьшения жёлтой полоски
    [Header("Image")]
    public Image redHP;
    public Image yellowHP;
    public Image greenHP;

    public void HealthBarRenderer(float hp, float maxHP)
    {
        fillAmountHP = hp / maxHP;

        float lerpTime = 0f;

        lerpTime += Time.deltaTime;
        redHP.fillAmount = Mathf.Lerp(redHP.fillAmount, fillAmountHP, redHP.fillAmount > greenHP.fillAmount ? lerpTime / RedDecreaseSpeed : lerpTime / RedFillingSpeed);
        yellowHP.fillAmount = Mathf.Lerp(yellowHP.fillAmount, fillAmountHP, yellowHP.fillAmount > redHP.fillAmount ? lerpTime / YellowDecreaseSpeed : 1);

        if (Mathf.Abs(yellowHP.fillAmount - greenHP.fillAmount) <= 0.002) //чтобы не стремились бесконечно друг к другу
        {
            yellowHP.fillAmount = greenHP.fillAmount;
        }
        if (Mathf.Abs(redHP.fillAmount - greenHP.fillAmount) <= 0.002)
        {
            redHP.fillAmount = greenHP.fillAmount;
        }
    }

    public virtual void UpdateHealthBar(float hp, float maxHP)
    {
        greenHP.fillAmount = hp / maxHP;
    }
}
