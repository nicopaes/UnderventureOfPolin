/* 
* Copyright (c) Bravarda Game Studio
* Little Prick Project 2017
*
*/
using UnityEngine;
using System.Collections;

public class HookMovement : MonoBehaviour {

	#region Public Variables
	[Header("Technical Stuff")]
	public Camera mainCamera;
	public GameObject Hook;
	public SceneFadeOut fadeInOut;

	[Space]
	public LayerMask hookableLayer;

	[Tooltip("This is the player speed")]
	[Range(0.1f,30f)]
	public float playerSpeed;

	[Tooltip("This is the inercia speed")]
	[Range(0.1f, 30f)]
	public float inerciaSpeed;

	[Space]
	[Header("SOUND")]
	public AudioClip wobbleSound;

	[Space]
	[HideInInspector]
	public bool Damage;


	[HideInInspector]
	public float stopFactor;

	#endregion

	#region Music Variables
	public AudioSource[] playerSource;
	//public AudioClip hookAttach;

	#endregion

	#region Private Variables

	private RaycastHit2D hookHit;
	private Rigidbody2D playerRb;
	private Vector2 movement;
	//[HideInInspector]
	public Vector2 Target;
	private GameObject theHook;
	private playerHealth playerHealth;
	private bool firstHook;

	private Animator playerAnimator;
	private bool Action;

	#endregion

	#region Start and Awake

	private void Awake()
	{
		playerHealth = GetComponent<playerHealth>();
		playerAnimator = GetComponent<Animator>();
		playerSource = GetComponents<AudioSource>();
		fadeInOut = GameObject.Find("FadeInOutSprite").GetComponent<SceneFadeOut>();
	}
	void Start () {
		Target = (Vector2)transform.position + new Vector2(0.1f, 0.1f);
		playerRb = GetComponent<Rigidbody2D>();
		playerRb.velocity = Vector2.zero;
		Damage = false;
		Cursor.visible = false;
		//audio = this.GetComponent<AudioSource>();
	}

	#endregion

	#region Fixed-Update²
	private void Update()
	{
		if (Vector2.Distance(Target, transform.position) < 1f)
		{
			stopFactor = 0.00001f;
		}
		else
		{
			stopFactor = 1f;
		}
		playerAnimator.SetBool("Action", Action);
	}
	void FixedUpdate () {

		theHook = GameObject.FindGameObjectWithTag("Hook");
		//Target = theHook.GetComponent<ShotMovement>().targetCollision;
		//Debug.Log(Vector2.Distance(Target, transform.position));
		if(fadeInOut.GameReady)
		{
			if (playerHealth.HP > 0)
			{
				if (!Damage)
				{
					if (theHook != null)
					{
						if (Target != new Vector2(-1, -1) && theHook.GetComponent<ShotMovement>().readyToPull)
						{
							float Accel = Mathf.Clamp(1 + (1 / (Vector2.Distance(transform.position, Target))), 1, 1.5f);

							Vector2 newPos = ((Target - (Vector2)transform.position).normalized * playerSpeed * Time.deltaTime * Accel);
							playerRb.MovePosition((Vector2)transform.position + newPos);

							//Debug.Log((Accel));
						}
						else
						{
							Vector2 newPos = ((Target - (Vector2)transform.position).normalized * inerciaSpeed * Time.deltaTime * stopFactor);
							playerRb.MovePosition((Vector2)transform.position + newPos);
						}
						if (theHook.GetComponent<ShotMovement>().targetCollision != new Vector2(-1, -1))
						{
							Target = theHook.GetComponent<ShotMovement>().targetCollision;
						}
						//Debug.Log(Target);

					}
					if (theHook == null)
					{
						Vector2 newPos = (((Target - (Vector2)transform.position).normalized * inerciaSpeed) * Time.deltaTime * stopFactor);
						playerRb.MovePosition((Vector2)transform.position + newPos);

					}
				}
			}
	}
}
	#endregion
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Action = true;
		playerSource[0].Stop();
		playerSource[0].PlayOneShot(wobbleSound,0.04f);
		StartCoroutine(ChangeAction());
	}
	#region Auxiliary Functions

	public void StartShake()
	{
		//mainCamera.GetComponent<CameraShake>().StartShake();
	}

	public IEnumerator Invulnerability(float seconds)
	{
		
		yield return new WaitForSeconds(seconds);
		Damage = false;

		float randomX = Random.Range(-0.2f, 0.2f);
		float randomY = Random.Range(-0.2f, 0.2f);

		Target = (Vector2)transform.position + new Vector2(randomX, randomY);
		//playerRb.velocity = Vector2.zero;
		//inerciaSpeed = 0;
		//playerSpeed = 15;
	}
	private IEnumerator ChangeAction()
	{
		yield return new WaitForSeconds(0.2f);
		Action = false;

	}
	#endregion
}
