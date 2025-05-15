using UnityEngine;
using UnityEngine.Events;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private DropItems _dropItems;
    [SerializeField] private UnityEvent<GameObject> OnOpen;
    [SerializeField] private Animator animator;
    private Looting _looting = new Looting();

    public void Interact()
    {
        animator.SetBool("Openning", true);
        OnOpen.Invoke(_looting.GiveMeFromItems(_dropItems.ListItems));
    }
}