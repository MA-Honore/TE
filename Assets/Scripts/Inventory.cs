using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    List<InventorySlot> Items;
 
	public Inventory()
	{

		Items = new List<InventorySlot>();
	}

	public int AddItem(ItemDefinition item, int amount)
	{
		InventorySlot slot = Items.Find(x => (x.getItem() == item && x.getQuantity() < item.maxStack));
		if (slot != null)
		{
			int remaining = slot.AddQuantity(amount);
			if(remaining > 0)
			{
				remaining = AddItem(item, remaining);
			}
			return remaining;
		
		} else {
			slot = Items.Find(x => x.getItem() == null);
			if(slot != null)
			{
				slot.setItem(item);
				int remaining = slot.AddQuantity(amount);
				if(remaining > 0)
				{
					remaining = AddItem(item, remaining);
				}
				return remaining;
			} else {
				return amount;
			}
		}
	}

	public void RemoveItem(ItemDefinition item, int amount)
	{
		

	}
 	
	public void Display() {
		foreach(InventorySlot slot in Items) {
			if(slot.getItem() != null) {
				Debug.Log(slot.getItem().name + " " + slot.getQuantity());
			}
		}
	}
	

	void Awake() {
	}

	void Start() {
		this.Display();
	}

	void Update() {
		
	}
}
