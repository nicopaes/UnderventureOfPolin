/* 
* Copyright (c) Bravarda Game Studio
* Little Prick Project 2017
*
*/
using UnityEngine;

public class eyeFollow : MonoBehaviour {

	#region Public Variables
	#endregion

	#region Private Variables
	#endregion 

	#region Start and Awake
	void Start () {
	}

	#endregion
	
	#region Fixed-Update²
	void Update () {

		Camera cam = Camera.main;
		Vector2 mousePoint;
		Vector3 mouse;
		// Distance from camera to object.  We need this to get the proper calculation.
		float camDis = cam.transform.position.y - transform.position.y;

		mousePoint = Input.mousePosition;
		// Get the mouse position in world space. Using camDis for the Z axis.
		mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));

		float AngleRad = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
		float angle = (180 / Mathf.PI) * AngleRad;
		transform.rotation = Quaternion.Euler(0, 0, angle);

	}
	#endregion

	#region Auxiliary Functions

	#endregion
}
