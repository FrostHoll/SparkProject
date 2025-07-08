using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Controller
{
    private PlayerMovement playerMovement;
    public GameObject weeeopen;
    public InputSystem_Actions inputActions;

    protected override void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        model = new PlayerModel(baseStats);
        model.HealthChanged += view.OnHealthChanged;
        base.Start();
        model.stats.IgnoreMask = LayerMask.GetMask("Player", "Weapon", "ignoreMask");
        model.stats.LayerMask = LayerMask.GetMask("Enemy");
        weapon.attackMask = model.stats; //временно
    }

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Enable();
        view = GetComponent<View>();
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
            AddWeapor(weeeopen);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            RemoveWeapon();
        }
    }
    public void StartAttack(InputAction.CallbackContext obj)
    {
        if (weapon != null)
        {
            weapon.StartOrStopAttack(true);
            view.StartAttackAnim();
        }
    }

    public void StopAttack(InputAction.CallbackContext obj)
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
