using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemCollectible : MonoBehaviour
{
    [SerializeField]
    public bool IsStackable { get; set; }

    [SerializeField]
    ItemDefinition itemDefinition;
    int amount = 1;

    public ItemDefinition GetItemDefinition()
    {
        return itemDefinition;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //other.gameObject.GetComponent<Inventory>().AddItem(itemDefinition, amount);
            //other.gameObject.GetComponent<Inventory>().Display();
            Destroy(gameObject);
        }
    }
}
