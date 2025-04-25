using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float MaxHP = 100f;
    public float HP = 100;
    private float fillAmount_HP = 0;

    [Header("lerpSpeeds")]
    public float lerpSpeed_Red = 0.4f;
    public float reducedSpeed_Red = 0.18f;
    public float lerpSpeed_Yellow = 1;
    [Header("Image")]
    public Image Red_HP;
    public Image Yellow_HP;
    public Image Green_HP;

    void Start()
    {
        Red_HP.fillAmount = HP / MaxHP;
    }

    void Update()
    {
        fillAmount_HP = HP / MaxHP;

        float lerpTime = 0f;

        if (Green_HP.fillAmount != Red_HP.fillAmount)
        {
            lerpTime += Time.deltaTime;
            Red_HP.fillAmount = Mathf.Lerp(Red_HP.fillAmount, fillAmount_HP, Red_HP.fillAmount > Green_HP.fillAmount ? lerpTime / reducedSpeed_Red : lerpTime / lerpSpeed_Red);
            Yellow_HP.fillAmount = Mathf.Lerp(Yellow_HP.fillAmount, fillAmount_HP, Yellow_HP.fillAmount > Red_HP.fillAmount ? lerpTime / lerpSpeed_Yellow : 1);
        }

        if (Input.GetKeyUp(KeyCode.E)) //для проверки
        {
            Hiealing(10f);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            TakeDamage(10f);
        }
    }

    public virtual void TakeDamage(float damage)
    {
        HP -= damage;
        Green_HP.fillAmount = HP / MaxHP;
    }

    public virtual void Hiealing(float healingAmount)
    {
        if (HP + healingAmount >= MaxHP) 
        {
            HP = MaxHP;
            Green_HP.fillAmount = HP / MaxHP;
            return;
        }
        HP += healingAmount;
        Green_HP.fillAmount = HP / MaxHP;
    }
}
