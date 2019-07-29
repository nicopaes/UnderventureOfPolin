/* 
* Copyright (c) Bravarda Game Studio
* Little Prick Project 2017
*
*/
using UnityEngine;

public class EscavadorMove : MonoBehaviour {

	#region Public Variables
	public Transform wayPoint;
	public float Speed;
	public float attackRange;
	#endregion

	#region Private Variables
	private bool moving;
	private bool lerp;
	private Vector2 originalPosition;
	private Rigidbody2D escavatorRb;
	#endregion 

	#region Start and Awake
	void Start () {
		originalPosition = transform.position;
		escavatorRb = GetComponent<Rigidbody2D>();
	}

	#endregion
	
	#region Fixed-Update²
	void FixedUpdate () {
		//transform.position = Vector2.Lerp(transform.position, wayPoint.position,0.1f);
		escavatorRb.MovePosition((Vector2)transform.position + ((Vector2)wayPoint.position - (Vector2)transform.position) * Speed * Time.fixedDeltaTime);

		if(Vector2.Distance(transform.position,originalPosition) > attackRange)
		{
			transform.position = originalPosition;
		}
	}
	#endregion

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.transform.CompareTag("Player"))
		{
			if(collision.transform.GetComponent<HookMovement>() == true)
			{
				collision.transform.GetComponent<playerHealth>().TakeDamage(2);
			}
		}
	}
	#region Auxiliary Functions
	private void OnDrawGizmos()
	{ 
		Gizmos.DrawWireSphere(originalPosition, attackRange);
	}
	#endregion
}
