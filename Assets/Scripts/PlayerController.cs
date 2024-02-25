using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{   
    private Vector2 _axisInput = Vector2.zero;
    [field: SerializeField] public float MoveForce { get; private set; } = 250f;
    
    [field: SerializeField] public CharacterState Idle {get; private set;}

    [field: SerializeField] public CharacterState Walk {get; private set;}

    [field: SerializeField] public StateAnimationSetDictionary StateAnimations {get; private set; }

    [field: SerializeField] public float WalkVelocityThreshold { get; private set;} = 0.05f;
    private Rigidbody2D _rb;

    private Animator _animator;

    private CharacterState _currentState;

    private AnimationClip _currentClip;

    private Vector2 _facingDir;

    private void Start(){
        _rb=GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _currentState = Idle;
    }

    private void Update(){
        if(_rb.velocity.magnitude > WalkVelocityThreshold){
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
    private void FixedUpdate(){
        Vector2 moveForce = _axisInput * MoveForce * Time.fixedDeltaTime;
        _rb.AddForce(moveForce);
    }
    private void OnMove(InputValue value){
        _axisInput = value.Get<Vector2>();
        Debug.Log(_axisInput);
        if(_axisInput != Vector2.zero){
            _facingDir = _axisInput;
        }
        
    }

    private void OnUse(InputValue value){

    }
}
