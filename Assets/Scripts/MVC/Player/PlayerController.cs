using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Controller
{
    [SerializeField] CharacterStats characterStats;
    private InventoryInputs inventoryInputs;
    private PlayerMovement playerMovement;
    public InputSystem_Actions inputActions;
    private PlayerInventory playerInventory;
    public Item dopWeapon;

    protected void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        inventoryInputs = GetComponent<InventoryInputs>();
        playerInventory = GetComponent<PlayerInventory>();
        model = new PlayerModel(CopyPlayerStats(characterStats));
        playerInventory.InitializationPlayerInventory(this);
        inventoryInputs.Initialization(toolbarController);
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

    public override void AddItemInInventory(Item item)
    {
        playerInventory.AddItem(item);
        base.AddItemInInventory(item);
    }

    public void MoveItemInInventory(InventoryListType where, int whereIndex, InventoryListType whereFrom, int whereFromIndex)
    {
        inventory.MoveItem(where, whereIndex, whereFrom, whereFromIndex);
    }

    public CharacterStats CopyPlayerStats(CharacterStats playerStats)
    {
        CharacterStats statsCopy = Instantiate(playerStats);
        return statsCopy;
    }
}
