using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DirectionAnimationSet", menuName = "DirectionAnimationSet")]
public class DirectionAnimationSet : ScriptableObject
{ 
    [field: SerializeField] public AnimationClip Up {get; private set;}

    [field: SerializeField] public AnimationClip Down {get; private set;}

    [field: SerializeField] public AnimationClip Right {get; private set;}

    [field: SerializeField] public AnimationClip Left {get; private set;}

    public AnimationClip GetFacingClip(Vector2 facingDirection){
        
        Vector2 closestDirection = GetClosestDirection(facingDirection);

        if(closestDirection == Vector2.left){
            return Left;
        }
        else if (closestDirection == Vector2.right){

            return Right;
        }
        else if(closestDirection == Vector2.up){
            return Up;

        }
        else if(closestDirection == Vector2.down){
            return Down;
        }else{
            throw new ArgumentException($"Direction not expected {closestDirection}");          
        }
    }

    public Vector2 GetClosestDirection(Vector2 inputDirection){
        Vector2 normalizedDirection = inputDirection.normalized;
        Vector2 closestDirection = Vector2.zero;
        float closestDistance = 0f;
        bool firstSet = false;
        Vector2[] directionChecked = new Vector2[4] {Vector2.down, Vector2.up, Vector2.right, Vector2.left};

        for(int i = 0; i < directionChecked.Length; i++){
            if(!firstSet){
                closestDirection = directionChecked[i];
                closestDistance = Vector2.Distance(inputDirection, directionChecked[i]);
                firstSet = true;
            }
            else {
                float nextDistance = Vector2.Distance(inputDirection,directionChecked[i]);
                if(nextDistance < closestDistance){
                    closestDistance = nextDistance;
                    closestDirection = directionChecked[i];
                }
            }
        }
        return closestDirection;

    }
}   
