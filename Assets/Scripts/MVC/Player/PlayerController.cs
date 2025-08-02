using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Controller
{
    [SerializeField] CharacterStats characterStats;
    private PlayerMovement playerMovement;
    public InputSystem_Actions inputActions;
    public BaseWeapon dopWeapon;

    protected void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        model = new PlayerModel(characterStats);
        repulsiveness = new Repulsiveness(this, model.stats);
        model.HealthChanged += view.OnHealthChanged;
        SetSide();
        if(weapon != null )
        {
            model.InitializeCurrentWeaponAttackSpeed(weapon.baseAttackTime);
            weapon.UpdateWeaponStats(model.stats, model.calculatedAttackSpeed);
            view.AttackSpeedAnimChanged(model.calculatedAttackSpeed);
        }
    }

    protected override void Awake()
    {
        base.Awake();
        inputActions = new InputSystem_Actions();
        inputActions.Enable();
    }

    private void OnEnable()
    {
        inputActions.Player.Attack.performed += StartAttack;
        inputActions.Player.Attack.canceled += StopAttack;
    }
    private void OnDisable()
    {
        inputActions.Player.Attack.performed -= StartAttack;
        inputActions.Player.Attack.canceled -= StopAttack;
    }



    protected override void Update()  
    {
        base.Update();

        playerMovement.Move(inputActions.Player.Move,model.stats.Speed);

        if (Input.GetKeyUp(KeyCode.E)) //для проверки
        {
            ApplyHealing(10f);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            TakeDamage(10f);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            AddWeapon(dopWeapon);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            RemoveWeapon();
        }
    }
    private void StartAttack(InputAction.CallbackContext obj)
    {
        if (weapon != null)
        {
            weapon.StartOrStopAttack(true);
            view.StartAttackAnim();
        }
    }

    private void StopAttack(InputAction.CallbackContext obj)
    {
        if (weapon != null)
        {
            weapon.StartOrStopAttack(false);
            view.StopAttackAnim();
        }
    }

    public override void Die()
    {
        
    }

    public override void SetSide(IAttackMask masks = null, string setTag = null, int layerIndex = 0)
    {
        model.stats.LayerMask = masks == null ? LayerMask.GetMask("Enemy") : masks.LayerMask;
        model.stats.IgnoreMask = masks == null ? LayerMask.GetMask("Player", "Weapon", "ignoreMask") : masks.IgnoreMask;
        gameObject.layer = layerIndex == 0 ? LayerMask.NameToLayer("Player") : layerIndex;
        gameObject.tag = setTag == null ? "Player" : setTag;
    }

    public void CollectArtifact(Artifact artifact)
    {
        AddArtifact(artifact);
    }
}
