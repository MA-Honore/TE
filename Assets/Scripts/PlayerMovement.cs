using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stamina))]
[RequireComponent(typeof(Rigidbody2D))]
public class EntityMouvement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Stamina staminaController;
    float speedX, speedY;
    private Vector2 direction;

    [Header("Sprint Settings")]
    public float speed = 100.0f;
    public float sprintBoost = 100.0f;
    public float staminaDecreaseSrpint = 10.0f;
    public float staminaMinimumSprint = 10.0f;

    private bool sprintKey = false;
    private bool canSprint = true;

    [Header("Dash Settings")]
    public float dashSpeed = 100.0f;
    public float dashTime = 0.5f;
    public float dashCooldown = 1.0f;
    public float staminaDecreaseDash = 10.0f;
    public float staminaMinimumDash = 10.0f;

    private bool dashKey = false;
    private bool canDash = true;
    private bool isDashing = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        staminaController = GetComponent<Stamina>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        sprintKey = Input.GetKey(KeyCode.LeftShift);

        dashKey = Input.GetKeyDown(KeyCode.Q);

        if (dashKey && canDash && (staminaController.GetStamina() >= staminaMinimumDash)) {
            StartCoroutine(Dash());
        }
    }

    void FixedUpdate() {      
        if(isDashing) {
            return;
        }

        if(!canSprint && !sprintKey) {
            canSprint = true;
        }
        if (sprintKey && canSprint && staminaController.GetStamina() > staminaMinimumSprint) {
            rb.velocity = direction * (speed + sprintBoost) * Time.deltaTime;
            staminaController.DecreaseStamina(staminaDecreaseSrpint);
            canSprint = staminaController.GetStamina() > staminaMinimumSprint;

        } else {
            rb.velocity = direction * speed * Time.deltaTime;
        }
    }

    private IEnumerator Dash() {
        isDashing = true;
        canDash = false;
        Debug.Log("Dash");
        rb.velocity = new Vector2(direction.x * dashSpeed, direction.y * dashSpeed);
        staminaController.DecreaseStamina(staminaDecreaseDash);
        yield return new WaitForSeconds(dashTime);
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
