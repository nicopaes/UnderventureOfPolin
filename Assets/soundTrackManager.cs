/* 
* Copyright (c) Bravarda Game Studio
* Little Prick Project 2017
*
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class soundTrackManager : MonoBehaviour {

	#region Public Variables
	[Header("Soundtrack")]

	public AudioClip menuMusic;
	public AudioClip levelMusic;

	#endregion

	#region Private Variables
	private AudioSource soundTrackSource;
	private bool playingLevel;
	#endregion 

	#region Start and Awake
	void Awake () {
		DontDestroyOnLoad(this.gameObject);
		soundTrackSource = GetComponent<AudioSource>();
	}

	#endregion
	
	#region Fixed-Update²
	void Update () {
		
	}
	#endregion
	
	void OnEnable()
	{
		//Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
		SceneManager.sceneLoaded += playMusic;
	}

	void OnDisable()
	{
		//Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
		SceneManager.sceneLoaded -= playMusic;
	}

	
	#region Auxiliary Functions
	void playMusic(Scene scene, LoadSceneMode mode)
	{
		if (scene.name == "Menu")
		{
			soundTrackSource.volume = 0.35f;
			soundTrackSource.clip = menuMusic;
			soundTrackSource.Play();
		}
		if (scene.name == "GoldLevel" && !playingLevel)
		{
			playingLevel = true;
			soundTrackSource.Stop();
			soundTrackSource.volume= 0.3f;
			soundTrackSource.clip = levelMusic;
			soundTrackSource.Play();
		}
}
	#endregion
}
