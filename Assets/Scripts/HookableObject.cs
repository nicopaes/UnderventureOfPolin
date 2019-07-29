/* 
* Copyright (c) Bravarda Game Studio
* Little Prick Project 2017
*
*/
using UnityEngine;

public class HookableObject : MonoBehaviour {

	#region Public Variables

	public bool Active;

	#endregion

	#region Private Variables

	#endregion 

	#region Start and Awake
	void Start () {
		Active = true;
	}

	#endregion
	
	#region Fixed-Update²
	void Update () {
		
	}
	#endregion

	#region Auxiliary Functions

	public void changeActiveState()
	{
		Active = !Active;
		if (gameObject.layer == 9)
		{
			this.gameObject.layer = 10;
		}
		else if (gameObject.layer == 10)
		{
			this.gameObject.layer = 9;
		}
	}

	/*
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.transform.CompareTag("Player"))
		{
			//changeActiveState();
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		Debug.Log("PlayerHasLeft");
		changeActiveState();
	}*/
	#endregion
}
