using UnityEngine;

public class Chest : ItemDropper, IInteractable // Теперь тут совсем пусто
{
    public void Interact(GameObject Player)
    {
        if (AlreadeyDropped) return;
        StartCoroutine(DropItem());
    }
}