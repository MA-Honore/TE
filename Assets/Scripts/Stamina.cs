using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    [SerializeField]
    private int stamina;

    [SerializeField]
    private int staminaMax;

    public void DecreaseStamina(int value)
    {
        stamina -= value;
        stamina = stamina < 0 ? 0 : stamina;
    }

    public void IncreaseStamina(int value)
    {
        stamina += value;
        stamina = stamina > staminaMax ? staminaMax : stamina;
    }

    public int GetStamina()
    {
        return stamina;
    }

    public int GetStaminaMax()
    {
        return staminaMax;
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
