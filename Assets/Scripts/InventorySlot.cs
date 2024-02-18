using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot
{
    private ItemDefinition item;
    private int quantity;
    private Inventory _Inventory;

    public InventorySlot(Inventory inventory) {
        this._Inventory = inventory;
    }

    public ItemDefinition GetItem() {
        return this.item;
    }

    public int GetQuantity() {
        return this.quantity;
    }

    public void SetItem(ItemDefinition item) {
        this.item = item;
        this.quantity = 0;
    }

    public void SetItem(ItemDefinition item, int quantity) {
        this.item = item;
        this.quantity = quantity;
    }

    public int AddQuantity(int quantity)
    {
        if(this.item == null) {
            return 0;
        }

        if(quantity + this.quantity > this.item.maxStack) {
            int remaining = (quantity + this.quantity) - this.item.maxStack;
            this.quantity = this.item.maxStack;
            return remaining;
        } else {
            this.quantity += quantity;
            return 0;
        }
    }

    public void EmptySlot() {
        this.item = null;
        this.quantity = 0;
    }

    public bool IsSlotEmpty() {
        return this.item == null;
    }

    public void RemoveQuantity(int quantity)
    {
        this.quantity -= quantity;
        if(this.quantity <= 0) {
            this.EmptySlot();
        }
    }

}
