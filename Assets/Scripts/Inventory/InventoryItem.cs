using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Item item;
    public InventoryListType currentInventoryType;
    public int currentIndex;

    [HideInInspector]public Image image;
    [HideInInspector]public Transform parentAfterDrag;

    public void InitialiseItem(Item item, int index, InventoryListType inventoryType)
    {
        image = GetComponent<Image>();
        this.item = item;
        currentIndex = index;
        currentInventoryType = inventoryType;
        image.sprite = item.image;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (InventoryInputs.inventoryInputs.isInventoryOpen)
        {
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            image.raycastTarget = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (InventoryInputs.inventoryInputs.isInventoryOpen)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (InventoryInputs.inventoryInputs.isInventoryOpen)
        {
            transform.SetParent(parentAfterDrag);
            image.raycastTarget = true;
        }
    }


}
