using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stamina))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Stamina staminaController;
    float speedX, speedY;
    private Vector2 direction;

    [Header("Global Settings")]
    public float speed = 250.0f;

    [Header("Sprint Settings")]
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

    
    [field: SerializeField] public CharacterState Idle {get; private set;}
    [field: SerializeField] public CharacterState Walk {get; private set;}
    [field: SerializeField] public StateAnimationSetDictionary StateAnimations {get; private set; }
    [field: SerializeField] public float WalkVelocityThreshold { get; private set;} = 0.05f;

    private Animator _animator;
    private CharacterState _currentState;
    private AnimationClip _currentClip;
    private Vector2 _facingDir;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        staminaController = GetComponent<Stamina>();
        _animator = GetComponent<Animator>();
        _currentState = Idle;
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        sprintKey = Input.GetKey(KeyCode.LeftShift);
        dashKey = Input.GetKeyDown(KeyCode.Q);

        if (dashKey && canDash && (staminaController.GetStamina() >= staminaMinimumDash)) {
            Debug.Log("Dash");
            Debug.Log("Position: " + transform.position);
            Debug.Log("Destination: " + new Vector3(transform.position.x + direction.x * dashSpeed, transform.position.y + direction.y * dashSpeed, 0));
            
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + direction.x * dashSpeed, transform.position.y + direction.y * dashSpeed), new Vector2(transform.position.x + direction.x * dashSpeed, transform.position.y + direction.y * dashSpeed), 8);
            
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
            }
        }

        AnimationRefresh(direction);
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
        rb.isKinematic = true;
        rb.velocity = new Vector2(direction.x * dashSpeed, direction.y * dashSpeed);
        staminaController.DecreaseStamina(staminaDecreaseDash);
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        rb.isKinematic = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private void AnimationRefresh(Vector2 direction){ 
        if(direction != Vector2.zero){
            _facingDir = direction;
        }
        if(rb.velocity.magnitude > WalkVelocityThreshold){
            _currentState = Walk;
        }
        else{
            _currentState = Idle;
        }
        AnimationClip expectedClip = StateAnimations.GetFacingClipFromState(_currentState, _facingDir);
        if(_currentClip == null || _currentClip != expectedClip){
            _animator.Play(expectedClip.name);
        }
    }
}
