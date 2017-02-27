using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryActivator : MonoBehaviour {

	public static bool isInventoryActive = false;

	[SerializeField]
	private GameObject inventoryObject;


	void Update () 
	{
			ActivateInventory (KeyCode.Escape);
	}


	void ActivateInventory(KeyCode keycode)
	{
		if(Input.GetKeyDown(keycode)&&!Dialogsystem.isInDialogue)
			{
		if (isInventoryActive) {
				isInventoryActive = false;
				inventoryObject.SetActive (false);
		} else {
				isInventoryActive = true;
				inventoryObject.SetActive (true);
		}
			}
	}
}
