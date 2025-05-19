using UnityEngine;

public class EnemyView : View
{
    [SerializeField] private GameObject enemyCanvas;
    public override void UpdateHealthBar(float hp, float maxHP)
    {
        if (hp != maxHP) enemyCanvas.SetActive(true);
        else enemyCanvas.SetActive(false);
        base.UpdateHealthBar(hp, maxHP);
    }
}
