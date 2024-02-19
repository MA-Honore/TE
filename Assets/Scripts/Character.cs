using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	[SerializeField]
	private Inventory inventory;
 
	void Awake()
	{
		inventory = GetComponent<Inventory>();
	}
	
}
