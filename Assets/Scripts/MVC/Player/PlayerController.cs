using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Controller
{
    public InputAction playerControls;
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerControls.Enable();
        playerMovement = GetComponent<PlayerMovement>();
        model = new PlayerModel(baseStats);
        model.HealthChanged += view.OnHealthChanged;
    }

    private void Update()
    {
        playerMovement.Move(playerControls,model.stats.Speed);

        if (Input.GetKeyUp(KeyCode.E)) //для проверки
        {
            ApplyHealing(10f);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            TakeDamage(10f);
        }
    }

    public void CollectArtifact(Artifact artifact)
    {
        AddArtifact(artifact);
    }
}
