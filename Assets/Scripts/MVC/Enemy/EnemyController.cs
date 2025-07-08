using UnityEngine;

public class EnemyController : Controller
{
    private BaseEnemy baseEnemy;
    private EnemyMovement enemyMovement;
    private EnemyState enemyState;

    public Transform player;
    public bool isAngry = false;
    protected override void Start()
    {
        baseEnemy = GetComponent<BaseEnemy>();
        enemyMovement = GetComponent<EnemyMovement>();
        model = new EnemyModel(baseStats);
        model.HealthChanged += view.OnHealthChanged;
        TransitionToState(baseEnemy.CreateEnemyPatrulState(this,model,weapon)); //изночально у врага состояние патрулирования
        base.Start();
        model.stats.IgnoreMask = LayerMask.GetMask("Enemy", "Weapon", "ignoreMask");
        model.stats.LayerMask = LayerMask.GetMask("Player");
        weapon.attackMask = model.stats; //временно
    }
    protected override void Update()
    {
        base.Update();

        if(enemyState != null) enemyState.StateExecute();

        if (Input.GetKeyUp(KeyCode.E)) //для проверки
        {
            ApplyHealing(10f);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            TakeDamage(10f);
        }
    }

    public void EnemyBlink() //используеться в анимации
    {
        enemyMovement.Blink(player);
    }

    public void EnemyStartAttack() //используеться в анимации
    {
        weapon.StartOrStopAttack(true);
    }

    public void EnemyStopAttack() //используеться в анимации
    {
        weapon.StartOrStopAttack(false);
    }

    public void AgrUbdate(Transform player, bool isAngry) 
    {
        this.player = player;
        this.isAngry = isAngry;
    }

    public void TransitionToState(EnemyState newState) //метод отвечает за смену состояния
    {
        enemyState = newState;
    }

    public override void Die()
    {
        enemyState = null; //если не обнулить состояние перед уничтожением то enemyState будет работать еще 1 кадр после уничтожения
        Destroy(gameObject);
    }
}
