using UnityEngine;
using System.Collections;

public class ChestController : InteractableController, IDroppable
{
    private ChestModel _model = new();
    [SerializeField] private LootTableModel _lootTableController;
    [SerializeField] public Animator Animator;

    public bool IsDropped { get; set; } = false;
    public override void Interact()
    {
        if (IsDropped) return;
        DropItems();
    }

    public void DropItems()
    {
        IsDropped = true;
        StartCoroutine(DropAnimation());
        ItemDropperController.DropItem(_lootTableController.GetRandomItem(), gameObject.transform.position);
    }

    private IEnumerator DropAnimation()
    {
        Animator.SetBool("Openning", true);
        yield return new WaitForSeconds(_model.TimeToDrop);
    }
}