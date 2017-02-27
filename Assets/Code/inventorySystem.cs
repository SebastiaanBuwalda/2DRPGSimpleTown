using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventorySystem : MonoBehaviour {

	public static List<Item> inventoryList = new List<Item>();

	public static int inventorySize = 2;

	public  static Text[] inventoryText;


	void Start()
	{
	inventoryText = GetComponentsInChildren<Text> ();
	}
		
	public static void UpdateInventoryText()
	{
		foreach(Item item in inventoryList)
		{
			inventoryText [inventoryList.IndexOf (item)].text = item.itemName;
		}
	}

	public static void RemoveItem(int index)
	{
		inventoryText [index].text = "-";
		inventoryList.RemoveAt (index);
	}
}
