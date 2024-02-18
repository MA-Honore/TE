using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMouvement : MonoBehaviour
{
    public float speed = 5.0f;
    float speedX, speedY;


    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal");
        speedY = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() {      
        rb.velocity = new Vector2(speedX, speedY).normalized  * speed * Time.deltaTime;
        
    }
}
