using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMouvement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 100.0f;
    public float sprintBoost = 100.0f;
    public float staminaDecrease = 10.0f;
    float speedX, speedY;
    bool sprint = false;
    bool dash = false;
    public float dashSpeed = 100.0f;
    public float dashTime = 0.5f;
    public float dashCooldown = 1.0f;


    Stamina staminaController;




    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        staminaController = GetComponent<Stamina>();
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal");
        speedY = Input.GetAxisRaw("Vertical");

        sprint = Input.GetKey(KeyCode.LeftShift);
        dash = Input.GetKeyDown("q");
    }

    void FixedUpdate() {      
        

        if (sprint && staminaController.GetStamina() > 0) {
            rb.velocity = new Vector2(speedX, speedY).normalized  * (speed + sprintBoost) * Time.deltaTime;
            staminaController.DecreaseStamina((int)staminaDecrease);
        } else if (dash) {
            rb.AddForce(new Vector2(speedX, speedY).normalized * dashSpeed, ForceMode2D.Impulse);
        } else {
            rb.velocity = new Vector2(speedX, speedY).normalized  * speed * Time.deltaTime;
        }

        
        
    }
}
