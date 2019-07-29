/* 
* Copyright (c) Bravarda Game Studio
* Little Prick Project 2017
*
*/
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class playerHealth : MonoBehaviour {

	#region Public Variables

	[Tooltip("This is the player's Health")]
	[Range(1,10)]
	public int HP;
	[HideInInspector]
	public bool TakingDamage;
	public AudioClip[] damageSounds = new AudioClip[4];
	public AudioClip healSound;
	public AudioClip vagalumeSound;
	[Space]
	[Header("Death Particles")]
	public GameObject deathParticles;
	[Space]
	public AudioClip[] deathSound = new AudioClip[3];
	public AudioClip deathMegaSound;
	#endregion

	#region Private Variables
	private AudioSource[] playerSources;
	#endregion

	#region Start and Awake
	private void Awake()
	{
		playerSources = GetComponents<AudioSource>();
	}
	void Start () {
		TakingDamage = false;
	}

	#endregion
	
	#region Fixed-Update²
	void Update () {
		if(HP <= 0)
		{
			//StartCoroutine(RestartScene(3));
			var deathParticle = Instantiate(deathParticles, transform.position, Quaternion.identity) as GameObject;
			deathParticle.GetComponent<AudioSource>().clip = deathSound[Random.Range(0, deathSound.Length)];
			deathParticle.GetComponent<AudioSource>().Play();

			Camera.main.GetComponent<AudioSource>().PlayOneShot(deathMegaSound,0.1f);
			Camera.main.GetComponent<CameraShake>().StartRestart();
			Destroy(this.gameObject);			
			//this.gameObject.SetActive(false);
			//this.GetComponent<SpriteRenderer>().enabled = false;
			//this.transform.GetChild(0).gameObject.SetActive(false);
			//this.transform.GetChild(1).gameObject.SetActive(false);
			//this.transform.GetChild(2).gameObject.SetActive(false);
			//this.transform.GetChild(3).gameObject.SetActive(false);
		}
	}
	#endregion

	#region Auxiliary Functions

	public void TakeDamage(int lifeLost)
	{
		if (lifeLost >= 0)
		{
			playerSources[1].Stop();
			playerSources[1].PlayOneShot(damageSounds[Random.Range(0, damageSounds.Length)],0.3f);
			Camera.main.GetComponent<CameraShake>().StartShake();
		}
		if (lifeLost < 0)
		{
			playerSources[1].Stop();
			playerSources[1].PlayOneShot(healSound,0.5f);
			playerSources[1].PlayOneShot(vagalumeSound,0.3f);
		}
		HP -= lifeLost;
	}

	IEnumerator RestartScene(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		SceneManager.LoadScene("FinalLevel");
	}
	#endregion
}
