using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	
	private Inventory _Inventory;
	private Stamina _Stamina;
 
	public Character(int staminaMax)
	{
		_Stamina = new Stamina(staminaMax);
		_Inventory = new Inventory();
	}

	public void dash() {

	}

	void start() {
		_Inventory.Display();
	}
	
}
