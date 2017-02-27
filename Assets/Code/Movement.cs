using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	[SerializeField]
	private Dialogsystem dialogSystem;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private float moveSpeed = 5;

	[SerializeField]
	private float interactionDistance = 10;


	void Update () {
		if (!Dialogsystem.isInDialogue&&!InventoryActivator.isInventoryActive) {
			MoveWithButton (KeyCode.LeftArrow, Vector2.left, 2);
			MoveWithButton (KeyCode.RightArrow, Vector2.right, 3);
			MoveWithButton (KeyCode.UpArrow, Vector2.up, 0);
			MoveWithButton (KeyCode.DownArrow, Vector2.down, 1);

			StopWalkingAnim (KeyCode.LeftArrow);
			StopWalkingAnim (KeyCode.RightArrow);
			StopWalkingAnim (KeyCode.UpArrow);
			StopWalkingAnim (KeyCode.DownArrow);

			Interaction (KeyCode.Space, Vector2.left, 2);
			Interaction (KeyCode.Space, Vector2.right, 3);
			Interaction (KeyCode.Space, Vector2.up, 0);
			Interaction (KeyCode.Space, Vector2.down, 1);
		}
			
	}


	void StopWalkingAnim(KeyCode keycode)
	{
		if (Input.GetKeyUp (keycode)) {
			animator.SetBool ("walking", false);
		}
			

	}

	void MoveWithButton(KeyCode keycode, Vector2 moveVector, int animationDir)
	{
		if (Input.GetKey (keycode)) {
			transform.Translate (moveVector * moveSpeed * Time.deltaTime);
			animator.SetInteger ("dir", animationDir);
			animator.SetBool ("walking", true);
		}
	}

	void Interaction(KeyCode keycode, Vector2 castingVector,int directionalInt)
	{
		RaycastHit2D hit2d;
		if (Input.GetKeyDown (keycode)) {
			if (animator.GetInteger ("dir") == directionalInt) {
				hit2d = Physics2D.Raycast (transform.position, castingVector, interactionDistance);
				if (hit2d.transform.gameObject.GetComponent<NPCSpeaker>() != null) {
					animator.SetBool ("walking", false);
					hit2d.transform.gameObject.GetComponent<NPCSpeaker> ().StartDialogue (animator.GetInteger ("dir"));
					dialogSystem.newDialogue(hit2d.transform.gameObject.GetComponent<NPCSpeaker> ().myLines,hit2d.transform.gameObject);

				}
			}
		}
	}
}
