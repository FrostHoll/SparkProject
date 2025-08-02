using UnityEngine;

public class EnemyView : View
{
    [SerializeField] private GameObject enemyCanvas;

    public override void OnHealthChanged(float hp, float maxHP)
    {
        base.OnHealthChanged(hp, maxHP);
        if (hp != maxHP) enemyCanvas.SetActive(true);
        else enemyCanvas.SetActive(false);
    }
}
