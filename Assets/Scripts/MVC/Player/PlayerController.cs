using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Controller
{
    private PlayerMovement playerMovement;
    public InputSystem_Actions inputActions;
    public BaseWeapon wiapone;

    protected void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        model = new PlayerModel(baseStats);
        repulsiveness = new Repulsiveness(this, model.stats);
        model.HealthChanged += view.OnHealthChanged;
        model.stats.IgnoreMask = LayerMask.GetMask("Player", "Weapon", "ignoreMask");
        model.stats.LayerMask = LayerMask.GetMask("Enemy");
        if(weapon != null )
        {
            weapon.AddStats(model.stats);
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
            AddWeapor(wiapone);
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

    public void CollectArtifact(Artifact artifact)
    {
        AddArtifact(artifact);
    }
}
