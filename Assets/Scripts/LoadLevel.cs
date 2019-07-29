/* 
* Copyright (c) Bravarda Game Studio
* Little Prickss Project 2017
*
*/
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour {

	#region Public Variables
	public AudioClip clickSound;
	private AudioSource[] startClick;

	#endregion

	#region Private Variables
	private Image startImage;
	private bool Clicked;
	#endregion 

	#region Start and Awake
	void Awake () {
		startImage = GetComponent<Image>();
		startClick = GetComponents<AudioSource>();
		startClick[0].pitch = 0.8f;
	}

	#endregion
	
	#region Fixed-Update²
	void Update () {
		if (Clicked)
		{
			//float newAlpha = startImage.color.a
			startImage.color = new Color(startImage.color.r, startImage.color.g, startImage.color.b, startImage.color.a - 0.01f);
			if(startImage.color.a == 0)
				startImage.enabled = false;
		}
	}
	#endregion

	#region Auxiliary Functions

	public void ButtonFadeOut()
	{
		startClick[0].Stop();
		startClick[0].PlayOneShot(clickSound, 0.3f);
		Clicked = true;
		GetComponent<Button>().enabled = false;
	}

	#endregion
}
