using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ItemCollectible : MonoBehaviour
{
    
    public ItemDefinition itemDefinition;
    
    
    private SpriteRenderer spriteRenderer;

    public ItemDefinition GetItemDefinition()
    {
        return itemDefinition;
    }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = itemDefinition.image;
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
            InventoryManager.instance.AddItem(itemDefinition);
            Destroy(gameObject);
        }
    }
}
