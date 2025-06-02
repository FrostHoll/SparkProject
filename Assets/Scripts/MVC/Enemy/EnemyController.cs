using UnityEngine;

public class EnemyController : Controller
{
    private BaseEnemy baseEnemy;
    private EnemyMovement enemyMovement;

    private Transform player;
    public bool isAngry = false;
    private void Start()
    {
        baseEnemy = GetComponent<BaseEnemy>();
        enemyMovement = GetComponent<EnemyMovement>();
        model = new EnemyModel(baseStats);
        model.HealthChanged += view.OnHealthChanged;
    }
    private void Update()
    {
        if (isAngry)
        {
            baseEnemy.EnemyAI(enemyMovement,player,view,model, weapon);
        }

        if (Input.GetKeyUp(KeyCode.E)) //для проверки
        {
            ApplyHealing(10f);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            TakeDamage(10f);
        }
        if (model.HP <= 0)
        {
            Die();
        }
    }

    public void EnemyBlink() //используеться в анимации
    {
        enemyMovement.Blink(player);
    }

    public void EnemyStartAttack()
    {
        weapon.StartOrStopAttack(true);
    }

    public void EnemyStopAttack()
    {
        weapon.StartOrStopAttack(false);
    }

    public void AgrUbdate(Transform _player, bool _isAngry) 
    {
        player = _player;
        isAngry = _isAngry;
    }
}
