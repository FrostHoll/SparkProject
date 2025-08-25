using UnityEngine;

public class Loot : Interactable
{
    [SerializeField]private Item item;

    public void Initialize(Item item)
    {
        this.item = item;
    }

    public override void Interact(PlayerController playerController)
    {
        playerController.AddItemInInventory(item);
        Destroy(gameObject);
    }
}
