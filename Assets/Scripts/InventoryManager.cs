using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{
	public static InventoryManager instance;

    public InventorySlot[] allSlots;
	public InventorySlot[] barSlots;
	public GameObject inventoryItemPrefab;

	private int selectedSlotIndex = -1;

	public void SelectSlot(int index) {
		if(index < 0 || index >= barSlots.Length) {
			return;
		}

		if(selectedSlotIndex != -1) {
			barSlots[selectedSlotIndex].Deselect();
		}

		selectedSlotIndex = index;
		barSlots[selectedSlotIndex].Select();
	}

	public bool AddItem(ItemDefinition item) {
		InventorySlot slot;
		InventoryItem slotItem;

		// Si l'item est deja dans l'inventaire, on augmente la quantité si possible
		if(item.isStackable) {
			for(int i = 0; i < allSlots.Length; i++) {
			 slot = allSlots[i];
			 slotItem = slot.GetComponentInChildren<InventoryItem>();
				if(slotItem != null && slotItem.item == item && slotItem.amount < item.maxStack) {
					slotItem.amount++;
					slotItem.RefreshAmountText();
					return true;
				}
			}
		}
		Debug.Log("Item is not stackable");
		// Sinon, on cherche un slot vide pour ajouter l'item
		for(int i = 0; i < allSlots.Length; i++) {
			 slot = allSlots[i];
			 slotItem = slot.GetComponentInChildren<InventoryItem>();
			if(slotItem == null) {
				SpawnItem(item, slot);
				return true;
			}
		}
		return false;
	}

	void SpawnItem(ItemDefinition item, InventorySlot slot) {
		GameObject itemObject = Instantiate(inventoryItemPrefab, slot.transform);
		InventoryItem inventoryItem = itemObject.GetComponent<InventoryItem>();
		inventoryItem.InitWith(item);
	}

	public ItemDefinition GetSelectedItem(bool use) {
		if(selectedSlotIndex == -1) {
			return null;
		}
		InventorySlot slot = barSlots[selectedSlotIndex];
		InventoryItem slotItem = slot.GetComponentInChildren<InventoryItem>();
		ItemDefinition item;

		if(slotItem != null) {
			item = slotItem.item;
			if(use) {
				slotItem.amount--;
				if(slotItem.amount <= 0) {
					Destroy(slotItem.gameObject);
				} else {
					slotItem.RefreshAmountText();
				}
			}

			return item;
		}
		return null;
	}
		





	// -------------------------
	// Monobehaviour
	// -------------------------
	void Awake() {
		instance = this;
	}

	void Start() {
		SelectSlot(0);
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.Alpha1)) {
			SelectSlot(0);
		} else if(Input.GetKeyDown(KeyCode.Alpha2)) {
			SelectSlot(1);
		} else if(Input.GetKeyDown(KeyCode.Alpha3)) {
			SelectSlot(2);
		} else if(Input.GetKeyDown(KeyCode.Alpha4)) {
			SelectSlot(3);
		} else if(Input.GetKeyDown(KeyCode.Alpha5)) {
			SelectSlot(4);
		} else if(Input.GetKeyDown(KeyCode.Alpha6)) {
			SelectSlot(5);
		} else if(Input.GetKeyDown(KeyCode.Alpha7)) {
			SelectSlot(6);
		} else if(Input.GetKeyDown(KeyCode.Alpha8)) {
			SelectSlot(7);
		} else if(Input.GetKeyDown(KeyCode.Alpha9)) {
			SelectSlot(8);
		} else if(Input.GetKeyDown(KeyCode.Alpha0)) {
			SelectSlot(9);
		}
	}
}
