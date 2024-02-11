using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    private int _Stamina;
    private int _StaminaMax;

    public int StaminaValue
    {
        get => _Stamina;
    }

    public int StaminaMax
    {
        get => _StaminaMax;
    }

    public Stamina(int staminaMax)
    {
        _StaminaMax = staminaMax;
        _Stamina = _StaminaMax;
    }

    public void DecreaseStamina(int value)
    {
        _Stamina -= value;
        _Stamina = _Stamina < 0 ? 0 : _Stamina;
    }

    public void IncreaseStamina(int value)
    {
        _Stamina += value;
        _Stamina = _Stamina > _StaminaMax ? _StaminaMax : _Stamina;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
