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
    Enemy enemy;
    Fighter player;
    List<RaycastResult> hits = new List<RaycastResult>();

    public Slot slot;

    void Start()
    {
        enemy = GameManager.instance.enemy;
        player = GameManager.instance.player;
    }

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

            Slot s = hit.gameObject.GetComponent<Slot>();
            if(s && s.item)
            {
                slotFound = s;
                Swap(slotFound);
                transform.position = slotFound.transform.position;

                //transform.SetAsLastSibling();
                if (slotFound.transform.parent != transform.parent && enemy.Check(item))
                    enemy.Hit(player.damage);
            }
            else
            {
                transform.position = transform.parent.transform.position;
            }
        }
    }

    #endregion
}
