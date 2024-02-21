using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class InventorySlotUI : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) {
        if(transform.childCount == 0) {
            ItemDraggable itemDraggable = eventData.pointerDrag.GetComponent<ItemDraggable>();
            itemDraggable.parentToReturnTo = transform;
        }


        
    }
}
