/* 
* Copyright (c) Bravarda Game Studio
* Little Prick Project 2017
*
*/
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	#region Public Variables

	[Tooltip("This is Target the camera will follow around")]
	public Transform cameraTarget;
	
	#endregion

	#region Private Variables

	#endregion 

	#region Start and Awake
	void Start () {
		
	}

	#endregion
	
	#region Fixed-Update²
	void Update () {
		if (cameraTarget != null)
		{
			Vector3 targetPosition = cameraTarget.position;
			Vector3 newCameraPosition = new Vector3(targetPosition.x, targetPosition.y, this.transform.position.z);

			this.transform.position = Vector3.Lerp(transform.position, newCameraPosition, 0.3f);
		}
	}
	#endregion

	#region Auxiliary Functions

	#endregion
}
