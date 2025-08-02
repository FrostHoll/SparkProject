using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private float fillAmountHP = 0;

    [Header("LerpSpeeds")]
    [SerializeField] private float RedFillingSpeed = 0.4f; //скорость заполнения красной полоски
    [SerializeField] private float RedDecreaseSpeed = 0.18f; //скорость уменьшения красной полоски
    [SerializeField] private float YellowDecreaseSpeed = 1; //скорость уменьшения жёлтой полоски
    [Header("Image")]
    [SerializeField] private Image redHP;
    [SerializeField] private Image yellowHP;
    [SerializeField] private Image greenHP;

    public void HealthBarRenderer(float hp, float maxHP)
    {
        if (greenHP.fillAmount != yellowHP.fillAmount || redHP.fillAmount != greenHP.fillAmount)
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
    }

    public virtual void UpdateHealthBar(float hp, float maxHP)
    {
        greenHP.fillAmount = hp / maxHP;
    }
}
