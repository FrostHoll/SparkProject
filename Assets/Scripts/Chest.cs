using UnityEngine;

public class Chest : ItemDropper, IInteractable // ������ ��� ������ �����
{
    public void Interact(GameObject Player)
    {
        if (AlreadeyDropped) return;
        StartCoroutine(DropItem());
    }
}