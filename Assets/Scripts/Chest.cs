using UnityEngine;
using System.Collections;

public class Chest : LootingSystem, IInteractable // Теперь тут совсем пусто Изм. Теперь чуть менее пусто.
{
    [SerializeField] protected Animator animator;
    public void Interact()
    {
        if (AlreadeyDropped) return;
        StartCoroutine(DropItem());
    }
    public override IEnumerator DropItem()
    {
        animator.SetBool("Openning", true);
        yield return new WaitForSeconds(TimeToDrop);
        JumpItem(GiveMeFromItems(_dropItems.ListItems));
        AlreadeyDropped = true;
    }
}