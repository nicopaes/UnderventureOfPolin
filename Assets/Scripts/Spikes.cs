/* 
* Copyright (c) Bravarda Game Studio
* John K. Paul Project 2017
*
*/
using UnityEngine;

public class Spikes : MonoBehaviour {

	#region Public Variables

	[Tooltip("this is the force that the Spike pushes the player")]
	[Range(50f, 1500f)]
	public float spikeForce;
	public Vector2 newTarget;
	#endregion

	#region Private Variables

	#endregion 

	#region Start and Awake
	void Start () {
		
	}

	#endregion
	
	#region Fixed-Update²
	void Update () {
		
	}
	#endregion


	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.transform.CompareTag("Player"))
		{
			//Debug.Log("The player hit a Spike");

			Destroy(GameObject.FindGameObjectWithTag("Hook"));
			collision.transform.GetComponent<HookMovement>().Damage = true;
			collision.transform.GetComponent<HookMovement>().StartCoroutine(collision.transform.GetComponent<HookMovement>().Invulnerability(0.5f));
			collision.transform.GetComponent<HookMovement>().Target = (Vector2)collision.transform.position + newTarget;
			//collision.transform.GetComponent<HookMovement>().StartShake();
			collision.transform.GetComponent<Rigidbody2D>().AddForce(transform.up * spikeForce);
			collision.transform.GetComponent<playerHealth>().TakeDamage(1);
		}
	}
	#region Auxiliary Functions
	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere((Vector2)transform.position + newTarget, 0.5f);
	}
	#endregion
}
