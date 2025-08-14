using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public ItemType itemType;
    public InventoryListType inventoryListType;
    private PlayerController playerController;
    public int slotIndex;

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            InventoryItem draggableItem = dropped.GetComponent<InventoryItem>();
            if (draggableItem.item.type == itemType)
            {
                AddItemInSlot(draggableItem);
            }
        }
    }

    protected virtual void AddItemInSlot(InventoryItem draggableItem)
    {
        draggableItem.parentAfterDrag = transform;
        playerController.MoveItemInInventory(draggableItem.currentInventoryType, draggableItem.currentIndex, inventoryListType, slotIndex);
        draggableItem.currentIndex = slotIndex;
        draggableItem.currentInventoryType = inventoryListType;
    }

    public void SetPlayerController(PlayerController playerController)
    {
        this.playerController = playerController;
    }
}
