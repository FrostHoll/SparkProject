using Unity.VisualScripting;
using UnityEngine;

//[RequireComponent (typeof(BaseEnemy),typeof(EnemyMovement))]
public class EnemyController : Controller
{
    private EnemyBaseAI baseEnemy;
    [SerializeField] private EnemyStats enemyStats;
    private EnemyMovement enemyMovement;
    private EnemyState enemyState;

    public Transform player;
    public bool isAngry = false;

    protected override void Awake()
    {
        base.Awake();
        model = new EnemyModel(CopyEnemyStats(enemyStats));
        SetSide();
    }

    protected void Start()
    {
        baseEnemy = GetComponent<EnemyBaseAI>();
        enemyMovement = GetComponent<EnemyMovement>();
        repulsiveness = new Repulsiveness(this, model.stats);
        model.HealthChanged += view.OnHealthChanged;
        if (weapon != null)
        {
            model.InitializeCurrentWeaponAttackSpeed(weapon.baseAttackTime);
            weapon.UpdateWeaponStats(model.stats, model.calculatedAttackSpeed);
            view.AttackSpeedAnimChanged(model.calculatedAttackSpeed);
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
        enemyState = null; //если не обнулить состояние перед уничтожением то enemyState будет работать еще 1 кадр после уничтожения
        baseEnemy.EnemyDie();
    }

    public override void SetSide(IAttackMask masks = null, string setTag = null, int layerIndex = 0) //метод отвечает за смену стороны. За или протиа игрока.
    {
        model.stats.LayerMask = masks == null ? LayerMask.GetMask("Player") : masks.LayerMask;
        model.stats.IgnoreMask = masks == null ? LayerMask.GetMask("Enemy", "Weapon", "ignoreMask") : masks.IgnoreMask;
        gameObject.layer = layerIndex == 0 ? LayerMask.NameToLayer("Enemy") : layerIndex;
        gameObject.tag = setTag == null ? "Enemy" : setTag;
    }

    public void SetEnemyAttackStats(float damage = 0, float repulsionForce = 0, float range = 0, float attackSpeed = 0) 
    {
        if(damage != 0) model.stats.Damage = damage;
        if(repulsionForce != 0) model.stats.RepulsionForce = repulsionForce;
        if(range != 0) model.stats.AttackRange = range;
        if (attackSpeed != 0)
        {
            model.stats.AttackSpeed = attackSpeed;
            model.AttackSpeedCalculate();
            view.AttackSpeedAnimChanged(model.calculatedAttackSpeed);
        }
    }

    public EnemyStats CopyEnemyStats(EnemyStats enemyStats)
    {
        EnemyStats statsCopy = Instantiate(enemyStats);
        return statsCopy;
    }

    public IEnemyStats TransferEnemyStats()
    {
        return enemyStats;
    }
}
