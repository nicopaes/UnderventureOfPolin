using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		newPos.z = 1;
		transform.position = newPos;

	}
}
