using UnityEngine;

public class Killer : MonoBehaviour
{
    public float deathTime = 5f;

    private Controller controller;

    private void Start()
    {
        controller = GetComponentInParent<Controller>();
    }

    private void Update()
    {
        if (controller == null)
        {
            this.enabled = false;
            return;
        }
        if(deathTime <= 0)
        {
            controller.Die();
        }
        else
        {
            deathTime -= Time.deltaTime;
        }
    }
}
