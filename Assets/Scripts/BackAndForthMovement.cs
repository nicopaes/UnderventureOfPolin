using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForthMovement : MonoBehaviour {
     private bool dirRight = true;
     public float speed = 2.0f;
     [Range(1f,50f)]
     public float platRange;
     private Vector2 startPosition;
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
         if (dirRight)
             transform.Translate (Vector2.right * speed * Time.deltaTime);
         else
             transform.Translate (-Vector2.right * speed * Time.deltaTime);
         
         if(transform.position.x >= startPosition.x + platRange) {
             dirRight = false;
         }
         
         if(transform.position.x <= startPosition.x - platRange) {
             dirRight = true;
         }		
	}
}
