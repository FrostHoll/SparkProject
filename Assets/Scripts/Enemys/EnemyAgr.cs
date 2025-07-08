using UnityEngine;
using UnityEngine.Events;

public class EnemyAgr : MonoBehaviour
{
    private bool isAngry = false;
    private Transform player;
    public UnityEvent<Transform, bool> EnemyAgrEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            isAngry = true;
            player = other.transform;
            EnemyAgrEvent?.Invoke(player, isAngry);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isAngry = false;
            EnemyAgrEvent?.Invoke(player, isAngry);
        }
    }
}
