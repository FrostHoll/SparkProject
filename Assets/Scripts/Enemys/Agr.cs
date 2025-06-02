using System;
using UnityEngine;
using UnityEngine.Events;

public class Agr : MonoBehaviour
{
    private bool isAngry = false;
    private Transform player;
    public UnityEvent<Transform, bool> EnemyAgr;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            isAngry = true;
            player = other.transform;
            EnemyAgr?.Invoke(player, isAngry);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isAngry = false;
            EnemyAgr?.Invoke(player, isAngry);
        }
    }
}
