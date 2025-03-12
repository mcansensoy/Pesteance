using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item_Slots : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped_item = eventData.pointerDrag;

            Draggable_Items drag_Items_slots = dropped_item.GetComponent<Draggable_Items>();

            drag_Items_slots.parent_AfterDrag = transform;
        }
    }
}
