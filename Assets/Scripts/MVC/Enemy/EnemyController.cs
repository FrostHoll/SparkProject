using UnityEngine;

//[RequireComponent (typeof(BaseEnemy),typeof(EnemyMovement))]
public class EnemyController : Controller
{
    private BaseEnemy baseEnemy;
    private EnemyMovement enemyMovement;
    private EnemyState enemyState;

    public Transform player;
    public bool isAngry = false;

    protected override void Awake()
    {
        base.Awake();
    }

    protected void Start()
    {
        baseEnemy = GetComponent<BaseEnemy>();
        enemyMovement = GetComponent<EnemyMovement>();
        model = new EnemyModel(baseStats);
        repulsiveness = new Repulsiveness(this, model.stats);
        model.HealthChanged += view.OnHealthChanged;
        model.stats.IgnoreMask = LayerMask.GetMask("Enemy", "Weapon", "ignoreMask");
        model.stats.LayerMask = LayerMask.GetMask("Player");
        if (weapon != null)
        {
            weapon.AddStats(model.stats);
        }
        TransitionToState(baseEnemy.CreateEnemyPatrulState(this,model,weapon)); //изночально у врага состояние патрулирования
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

    public void AgrUpdate(Transform player, bool isAngry) 
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
        baseEnemy.EnemyDie(enemyState);
    }
}
