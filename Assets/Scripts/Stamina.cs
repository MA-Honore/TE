using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    [SerializeField]
    private float stamina;

    [SerializeField]
    private float staminaMax;

    [SerializeField]
    private float regenRate;


    public void DecreaseStamina(float value)
    {
        stamina -= value;
        stamina = stamina < 0 ? 0 : stamina;
    }

    public void IncreaseStamina(float value)
    {
        stamina += value;
        stamina = stamina > staminaMax ? staminaMax : stamina;
    }

    public float GetStamina()
    {
        return stamina;
    }

    public float GetStaminaMax()
    {
        return staminaMax;
    }

    void Start()
    {
        stamina = staminaMax;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(stamina < staminaMax)
        {
            IncreaseStamina(regenRate);
        }
    }

    

    
}
