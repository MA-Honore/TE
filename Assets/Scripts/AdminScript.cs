using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminScript : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public ItemDefinition[] itemsToSpawn;
    
    public void SpawnItems(int id) {
        bool added = inventoryManager.AddItem(itemsToSpawn[id]);
        if(!added) {
            Debug.Log("Inventory is full");
        }
    }
}
