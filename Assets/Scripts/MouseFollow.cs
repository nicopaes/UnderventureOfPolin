/* 
* Copyright (c) Bravarda Game Studio
* Little Prick Project 2017
*
*/
using UnityEngine;

public class MouseFollow : MonoBehaviour {

	#region Public Variables

	public Camera mainCamera;

	#endregion

	#region Private Variables

	#endregion 

	#region Start and Awake
	void Start () {
		
	}

	#endregion
	
	#region Fixed-Update²
	void Update () {
		Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
		newPosition.Set(newPosition.x, newPosition.y, 0);
		transform.localPosition = newPosition.normalized;
	}
	#endregion

	#region Auxiliary Functions

	#endregion
}
