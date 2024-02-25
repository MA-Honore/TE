using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    [Header("UI References")]
    public Image image;
    public Text amountText;

    [HideInInspector] public ItemDefinition item;
    [HideInInspector] public int amount = 1;

    [HideInInspector] public Transform parentToReturnTo;

    // -------------------------

    public void InitWith(ItemDefinition item) {
        this.item = item;
        image.sprite = item.image;
        RefreshAmountText();
    }

    public void RefreshAmountText() {
        amountText.text = amount.ToString();
        amountText.gameObject.SetActive(amount > 1);
    }


    // -------------------------
    // Drag and Drop
    // -------------------------
    public void OnBeginDrag(PointerEventData eventData) {
        parentToReturnTo = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        transform.SetParent(parentToReturnTo);
        image.raycastTarget = true;
    }
}
