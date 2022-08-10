using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopItemUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;

    ShopItem item;

    public bool dragging;
    public Transform originalParent;
    public Canvas canvas;
    List<RaycastResult> hits = new List<RaycastResult>();

    public Slot slot;

    public void SetItem(ShopItem i)
    {
        item = i;
        if (image)
        {
            if (item)
            {
                image.sprite = item.icon;
                image.color = item.color;
            }
            gameObject.SetActive(item != null);
        }
    }

    protected void Swap(Slot newParent)
    {
        ShopItemUI other = newParent.item as ShopItemUI;
        if (other)
        {
            ShopItem ours = item;
            ShopItem theirs = other.item;

            slot.UpdateItem(theirs);
            other.slot.UpdateItem(ours);
        }
    }

    #region DraggingCode
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (originalParent == null) originalParent = transform.parent;
        if (canvas == null) canvas = GetComponentInParent<Canvas>();
        transform.SetParent(canvas.transform, true);
        transform.SetAsLastSibling();
        dragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragging)
            transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Slot slotFound = null;
        EventSystem.current.RaycastAll(eventData, hits);
        foreach(RaycastResult hit in hits)
        {
            //TODO: found out how the slots item is assigned then get it to swap.
            //Change second inventory to single item inventory and have it as "Active" item.
            //When switched check it against enemy type (add enemy types)
            Slot s = hit.gameObject.GetComponent<Slot>();
            if (s && s.item == null)
            {
                slotFound = s;
                transform.position = slotFound.transform.position;
                Debug.Log("Hit");
            }
            else if(s && s.item != null)
            {
                slotFound = s;
                Swap(slotFound);
                transform.position = slotFound.transform.position;
                Debug.Log("Swapped");
            }
            else
            {

            }
        }
    }

    #endregion
}
