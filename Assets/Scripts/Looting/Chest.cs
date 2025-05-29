using UnityEngine;
using UnityEngine.Events;

public class Chest : Interactable
{
    [SerializeField] private Animator animator;
    [SerializeField] private LootTable lootTable;
    [SerializeField] private UnityEvent<GameObject, Vector3, float> OnOpen;
    [SerializeField] private float timeToDrop = 1f;
    public bool IsDropped { get; set; } = false;

    public override void Interact(PlayerController playerController)
    {
        if (IsDropped) return;
        IsDropped = true;
        animator.SetBool("Openning", true);
        OnOpen?.Invoke(lootTable.GetRandomItem(), gameObject.transform.position, timeToDrop);
    }

    
}