/* 
* Copyright (c) Bravarda Game Studio
* Little Pricks Project 2017
*
*/
using UnityEngine;

public class HookRotation : MonoBehaviour {

	#region Public Variables
	public GameObject Hook;
	public ParticleSystem shotingParticles;

	[Space]
	[Header("Sound")]
	//[System.Serializable]
	public AudioClip[] hookShotPolinSound = new AudioClip[5];
	public AudioClip hookShotSound;

	#endregion

	#region Private Variables
	private GameObject theHook;
	private AudioSource[] hookShotSource;
	#endregion 

	#region Music Variables
	#endregion

	#region Start and Awake
	void Awake () {
		hookShotSource = GetComponents<AudioSource>();
	}

	#endregion
	
	#region Fixed-Update²
	void Update () {
		Turning();
		if (Input.GetMouseButtonDown(0) && GameObject.FindGameObjectWithTag("Hook") == null)
		{
			hookShotSource[0].Stop();
			hookShotSource[0].PlayOneShot(hookShotPolinSound[Random.Range(0, hookShotPolinSound.Length)], 0.1f);
			hookShotSource[1].Stop();
			hookShotSource[1].PlayOneShot(hookShotSound,0.1f);
			//shotingParticles.Stop();
			//shotingParticles.Play();
			GameObject hook = Instantiate(Hook, transform.position, Quaternion.identity) as GameObject;
			Vector3 eulerRotation = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
			hook.transform.rotation = Quaternion.Euler(eulerRotation);

			theHook = hook;
		}
		if (Input.GetMouseButtonDown(0) && (theHook.GetComponent<ShotMovement>().readyToPull == true))
		{
			Destroy(theHook);
		}
	}
	#endregion

	private void Turning()
	{
		//Debug.Log(numControllers);
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


	#region Auxiliary Functions

	#endregion
}
