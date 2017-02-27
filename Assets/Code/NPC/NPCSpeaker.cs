using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpeaker : MonoBehaviour {

	[SerializeField]
	private bool lookAtADirection = true;

	private NPCGiveItem npcGiveItem;
	private NPCRequireItem npcReqItem;

	private Item givingItem;

	private SpriteRenderer spriteRenderer;
	
	public string[] myLines;

	[SerializeField]
	private Sprite upSprite;

	[SerializeField]
	private Sprite downSprite;

	[SerializeField]
	private Sprite leftSprite;

	[SerializeField]
	private Sprite rightSprite;



	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
		npcGiveItem = GetComponent<NPCGiveItem> ();
		npcReqItem = GetComponent<NPCRequireItem> ();
	}

	public void StartDialogue(int directionalInt)
	{
		if (lookAtADirection) {
			switch (directionalInt) {
			case 0:
				spriteRenderer.sprite = downSprite;
				break;
			case 1:
				spriteRenderer.sprite = upSprite;
				break;
			case 2:
				spriteRenderer.sprite = rightSprite;
				break;
			case 3:
				spriteRenderer.sprite = leftSprite;
				break;
			}
		}
		if (npcReqItem != null) {
			if (npcReqItem.CheckForItem ()) 
			{
				myLines = npcReqItem.getItemDialogue;
			}
		}

	}

	public void endDialogue()
	{
		if (npcGiveItem!=null) 
		{
			inventorySystem.inventoryList.Add (npcGiveItem.givingItem);
			inventorySystem.UpdateInventoryText ();
			myLines = npcGiveItem.afterItemDialogue;
			npcGiveItem.enabled = false;

		}
	}
}
