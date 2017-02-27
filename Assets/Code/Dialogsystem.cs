using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogsystem : MonoBehaviour {


	public static bool isInDialogue = false;


	[SerializeField]
	private Text dialogText;

	[SerializeField]
	private GameObject dialogObject;

	[SerializeField]
	private string[] dialogList;

	private int lineID = 0;

	[SerializeField]
	private float letterDelay = 1;

	private bool expectInput = false;

	private GameObject endNPC;

	public void newDialogue(string[] lines, GameObject NPC)
	{
		dialogList = lines;
		endNPC = NPC;
		NewLine ();
	}

	void NewLine()
	{
		isInDialogue = true;
		dialogObject.SetActive (true);
		dialogText.text = "";

		for(int i = 0; i<dialogList[lineID].Length; i++)
		{
			StartCoroutine (NextChar (i));
		}
		StartCoroutine (WaitForNewLine());
	}

	void EndSystem()
	{

		endNPC.GetComponent<NPCSpeaker> ().endDialogue ();
		expectInput = false;
		lineID = 0;
		isInDialogue = false;
		dialogObject.SetActive (false);
	}


	IEnumerator NextChar(int charID)
	{
		
		yield return new WaitForSeconds (letterDelay * (charID + 1));
		char c = dialogList [lineID][charID];
		dialogText.text += c;
	}

	IEnumerator WaitForNewLine()
	{
		yield return new WaitForSeconds (letterDelay * (dialogList [lineID].Length + 1));
		expectInput = true;
	}

	void Update()
	{
		if (expectInput) 
		{
			if (Input.GetKeyDown ("space")) 
			{
				if (lineID + 1 < dialogList.Length) {
					lineID++;
					NewLine ();
					expectInput = false;
				} else {
					//End Dialogue
					EndSystem();
				}
			}
		}
	}
}
