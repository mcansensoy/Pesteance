using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable_Items : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{ 
    [HideInInspector] public Transform parent_AfterDrag;
    public Image image_;


    public void OnBeginDrag(PointerEventData eventData)
    {
        parent_AfterDrag = transform.parent;
        transform.SetParent(transform.parent.parent);
        transform.SetAsLastSibling();
        image_.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parent_AfterDrag);
        image_.raycastTarget = true;
    }
}
