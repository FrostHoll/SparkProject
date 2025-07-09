using UnityEngine;

public class SlimeBodyWeapon : MeleeWeapon
{
    [SerializeField] private float repulsionForce = 8;
    private Controller ownerController;

    private void Start() 
    {
        ownerController = GetComponentInParent<Controller>(); 
    }

    public override void DamageTrigger(Controller controller, GameObject attacker)
    {
        base.DamageTrigger(controller, attacker);
        ownerController.repulsiveness.ApplyRepulsion(attacker, repulsionForce);
    }
}
