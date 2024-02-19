using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemDefinition")]
public class ItemDefinition : ScriptableObject
{
    [field: SerializeField]
    public bool isStackable { get; set; }

    [field: SerializeField]
    public new string name { get; set; }

    [field: SerializeField]
    public int maxStack { get; set; }

    [field: SerializeField]
    [field: TextArea]
    public string description { get; set; }
}
