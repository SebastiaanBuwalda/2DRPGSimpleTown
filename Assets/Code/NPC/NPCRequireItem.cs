using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRequireItem : MonoBehaviour {

	[SerializeField]
	private string itemName;

	public string[] getItemDialogue;
	public string[] afterGetItemDialogue;


	public bool CheckForItem()
	{
		foreach (Item item in inventorySystem.inventoryList) 
		{
			if (item.itemName == itemName) {
				inventorySystem.RemoveItem (inventorySystem.inventoryList.IndexOf (item));
				return true;
			} else
				return false;
		}
		return false;
	}
}
