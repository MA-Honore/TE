using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField]
    ItemDefinition itemDefinition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onCollisionEnter(Collision other)
    {
         Debug.Log("Collision Detected");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Item Collected");
            //Inventory.instance.AddItem(itemDefinition);
            Destroy(gameObject);
        }
    }
}
