using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Controller
{
    private PlayerMovement playerMovement;
    public GameObject weeeopen;
    public InputSystem_Actions inputActions;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        model = new PlayerModel(baseStats);
        model.HealthChanged += view.OnHealthChanged;
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



    private void Update()  
    {
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
            view.ChangeAttackAnim(true);
        }
    }

    public void StopAttack(InputAction.CallbackContext obj)
    {
        if (weapon != null)
        {
            weapon.StartOrStopAttack(false);
            view.ChangeAttackAnim(false);
        }
    }
}
