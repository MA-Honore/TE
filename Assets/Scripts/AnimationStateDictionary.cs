using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StateAnimationSetDictionary : SerializableDictionary<CharacterState,DirectionAnimationSet>
    {
        public AnimationClip GetFacingClipFromState(CharacterState characterState,Vector2 facingDirection){
        if(TryGetValue(characterState, out DirectionAnimationSet animationSet)){
            return animationSet.GetFacingClip(facingDirection);
        }
        else {
            Debug.LogError($"Character state {characterState.name} is not found");
        }
        return null;
    }

    }
