using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemDefinition")]
public class ItemDefinition : ScriptableObject {

    public new string name;
    public int maxStack = 64;
    public bool isStackable = true;
    public ItemType type;
    public Sprite image;
    
    
    [field: TextArea]
    public string description;
}

public enum ItemType
{
    Consumable,
    Equipment,
    Ressource
}


