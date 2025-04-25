using System;
using UnityEditor.PackageManager;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public float rotationSpeed = 45f;
    public float enemySpeed = 10;
    private bool isAngry = false;
    public Health enemyHeath;
    public Transform player;

    private void Update()
    {
        if (isAngry)
        {
            LookAtPlayer(player.transform);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isAngry = true;
        }
    }

    private void LookAtPlayer(Transform player)
    {
        Vector3 targetDirection = player.position - transform.position;
        targetDirection.y = 0;
        Quaternion targetEnemyRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetEnemyRotation, Time.deltaTime * rotationSpeed);
    }
}
