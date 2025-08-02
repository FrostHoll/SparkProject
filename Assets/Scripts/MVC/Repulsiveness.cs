using UnityEngine;

public class Repulsiveness 
{
    Rigidbody rb;
    Controller controller;
    IRepulsionResistance repulsionResistance;

    public Repulsiveness(Controller controller, IRepulsionResistance repulsionResistance)
    {
        rb = controller.GetComponent<Rigidbody>();
        this.controller = controller;
        this.repulsionResistance = repulsionResistance;
    }

    public void ApplyRepulsion(GameObject source, float force)
    {
        float currentForce = force * (1 - repulsionResistance.RepulsionResistance);
        Vector3 repulsionDirection = (controller.transform.position - source.transform.position).normalized;

        repulsionDirection.y = 0f; 
        repulsionDirection = repulsionDirection.normalized;

        float verticalSpeed = Mathf.Sin(30 * Mathf.Deg2Rad) * currentForce;
        float horizontalSpeed = Mathf.Cos(30 * Mathf.Deg2Rad) * currentForce;

        rb.AddForce(repulsionDirection * horizontalSpeed + Vector3.up * verticalSpeed, ForceMode.Impulse);
    }
}
