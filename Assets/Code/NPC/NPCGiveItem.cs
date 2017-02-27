using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGiveItem : MonoBehaviour {

	[SerializeField]
	private string itemName;

	[SerializeField]
	private string itemDescription;

	public string[] afterItemDialogue;

	public Item givingItem;

	void Start()
	{
		givingItem.itemName = itemName;
		givingItem.itemInfo = itemDescription;
	}
}
