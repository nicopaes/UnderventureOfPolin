/* 
* Copyright (c) Bravarda Game Studio
* Litlle Prick Project 2017
*
*/
using UnityEngine;
using System.Collections;

public class ShotMovement : MonoBehaviour {

	#region Public Variables

	[Tooltip("This is the speed of the Hook")]
	[Range(1f,100f)]
	public float hookSpeed = 100f;
	[Header("Public Variables")]
	[Tooltip("This is the range of the hook")]
	[Range(0.1f, 30f)]
	public float hookRange;
	public bool readyToPull;
	public bool going;
	[Space]
	[Header("Sound")]
	public AudioClip[] impact = new AudioClip[2];

	[HideInInspector]
	public Vector2 targetCollision;
	#endregion

	#region Private Variables

	private Rigidbody2D hookRb;
	private Vector2 startPosition;
	private AudioSource hookSource;
	
	#endregion 

	#region Start and Awake
	void Awake () {
		hookRb = GetComponent<Rigidbody2D>();
		hookSource = GetComponent<AudioSource>();
	}
	private void Start()
	{
		targetCollision = new Vector2(-1, -1);
		readyToPull = false;
		going = true;
		StartCoroutine(destroyAfter(3f));
	}

	#endregion

	#region Fixed-Update²
	private void Update()
	{
		var lineRenderer = GetComponent<LineRenderer>();
		if (GameObject.FindGameObjectWithTag("Player") != null)
		{
			Vector2 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
			lineRenderer.SetPosition(0, transform.position);
			lineRenderer.SetPosition(1, playerPosition);
		}
	}

	void FixedUpdate () {
		//hookRb.velocity = new Vector2 (1f,1f);
		if (going)
		{
			Vector3 newPos = transform.right * Time.deltaTime * 100;
			hookRb.MovePosition(transform.position + newPos);
		}
		if (GameObject.FindGameObjectWithTag("Player") != null)
		{
			Vector2 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

			if (Vector2.Distance(playerPos, transform.position) > hookRange)
			{
				going = false;
			}
			if (!going)
			{
				hookRb.MovePosition((Vector2)transform.position + (playerPos - (Vector2)transform.position) * hookSpeed / 5 * Time.fixedDeltaTime);
				//GetComponent<Collider2D>().enabled = false;
				this.gameObject.layer = 12;
				//if(transform.localScale.x >= 0)
				//transform.localScale -= new Vector3(0.001f, 0.001f, 0);
				//transform.GetChild(0).GetComponent<TrailRenderer>().endWidth = 0.1f;
			}
		}
	}
	#endregion

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.CompareTag("Hookable"))
		{
			hookSource.Stop();
			hookSource.PlayOneShot(impact[1],0.5f);
			targetCollision = collision.contacts[0].point;
			readyToPull = true;
			going = false;
		}
		if (!going)
		{
			if (collision.transform.CompareTag("Hookable"))
			{
				Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
			}
			else if (collision.transform.CompareTag("Player"))
			{
				//Debug.Log("GunHook Collided");
				Destroy(this.gameObject);
			}

		}
		//StartCoroutine(destroyAfter(0.1f));
		hookSpeed = 0;
	}
	IEnumerator destroyAfter(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		Destroy(this.gameObject);
	}
	#region Auxiliary Functions

	#endregion
}
