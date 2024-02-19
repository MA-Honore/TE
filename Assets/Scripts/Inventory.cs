using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    List<InventorySlot> items;

	public int size = 4;
 
	public void init()
	{
		items = new List<InventorySlot>();
		for(int i=0; i<size; i++)
		{
			items.Add(new InventorySlot(this));
		}
	}

	public int AddItem(ItemDefinition item, int amount)
	{
		InventorySlot slot = items.Find(x => (x.GetItem() == item && x.GetQuantity() < item.maxStack));
		if (slot != null)
		{
			int remaining = slot.AddQuantity(amount);
			if(remaining > 0)
			{
				remaining = AddItem(item, remaining);
			}
			return remaining;
		
		} else {
			
			slot = items.Find(x => x.IsSlotEmpty());
			if(slot != null)
			{
				slot.SetItem(item);
				int remaining = slot.AddQuantity(amount);
				if(remaining > 0)
				{
					remaining = AddItem(item, remaining);
				}
				return remaining;
			} else {
				return 10;
			}
		}
	}

	

	public void RemoveItem(ItemDefinition item, int amount)
	{
		

	}
 	
	public void Display() {
		int i=1;
		foreach(InventorySlot slot in items) {
			if(!slot.IsSlotEmpty()) {
				Debug.Log(i + " | Item: " + slot.GetItem().name + " | Nombre: " + slot.GetQuantity());
				i++;
			}
		}
	}

	public bool IsFull() {
		return items.Find(x => x.IsSlotEmpty()) == null;
	}
	

	void Awake() {
		init();
	}

	void Start() {
		
	}

	void Update() {
		
	}
}
