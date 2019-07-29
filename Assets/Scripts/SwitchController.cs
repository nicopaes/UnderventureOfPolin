using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour {

	public GameObject Player;
	//private SpriteRenderer myRenderer;
	private bool collisionHappened;
	private Vector3 doorMovement;
	public Animator myAnimator;
	public GameObject Door1;

	// Use this for initialization
	void Start () {
		//myRenderer = this.GetComponent<SpriteRenderer>();
		collisionHappened = false;
		myAnimator = this.GetComponent<Animator>();
		myAnimator.SetBool ("turnedON", false);
	}

	// Update is called once per frame
	void Update () {
		activateSwitch();
	}

	void OnCollisionEnter2D (Collision2D Player)
	{	
		//Debug.Log("Collision happening.");
		Player = Player;
		collisionHappened = true;
	}

	void activateSwitch () 
	{
		if (collisionHappened == true)
		{
			myAnimator.SetBool ("turnedON", true);
			//Debug.Log("Collision happened.");
			Destroy(Door1, 0.0F);
		}	
	}
}
