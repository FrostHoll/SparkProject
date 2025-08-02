using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAgr : MonoBehaviour
{
    private SphereCollider agrCollider;
    public string targetTag = "Player";

    private bool isAngry = false;
    private Transform target;
    public UnityEvent<Transform, bool> EnemyAgrEvent;

    public List<Transform> targetsInTrigger = new List<Transform>();

    private void Start()
    {
        agrCollider = GetComponent<SphereCollider>();
        agrCollider.radius = GetComponentInParent<EnemyController>().TransferEnemyStats().AgrRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            if (!targetsInTrigger.Contains(other.transform))
            {
                targetsInTrigger.Add(other.transform);
            }
            if (!isAngry && targetsInTrigger.Count > 0)
            {
                isAngry = true;
                target = targetsInTrigger[0];
                EnemyAgrEvent?.Invoke(target, isAngry);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            if (targetsInTrigger.Contains(other.transform))
            {
                targetsInTrigger.Remove(other.transform);
            }
            if (isAngry && targetsInTrigger.Count == 0)
            {
                isAngry = false;
                target = null; 
                EnemyAgrEvent?.Invoke(target, isAngry);
            }
        }
    }
}
