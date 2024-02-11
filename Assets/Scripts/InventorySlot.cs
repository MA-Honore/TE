using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot
{
    private ItemDefinition _Item;
    private int _Quantity;
    private Inventory _Inventory;

    public InventorySlot(Inventory inventory) {
        this._Inventory = inventory;
    }

    public ItemDefinition getItem() {
        return this._Item;
    }

    public int getQuantity() {
        return this._Quantity;
    }

    public void setItem(ItemDefinition item) {
        this._Item = item;
        this._Quantity = 0;
    }

    public int AddQuantity(int quantity)
    {
        if(this._Item == null) {
            return 0;
        }

        if(quantity + this._Quantity > this._Item.maxStack) {
            int remaining = (quantity + this._Quantity) - this._Item.maxStack;
            this._Quantity = this._Item.maxStack;
            return remaining;
        } else {
            this._Quantity += quantity;
            return 0;
        }
    }

    public void emptySlot() {
        this._Item = null;
        this._Quantity = 0;
    }

    public void removeQuantity(int quantity)
    {
        this._Quantity -= quantity;
        if(this._Quantity <= 0) {
            this.emptySlot();
        }
    }

}
