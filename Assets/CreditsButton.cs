/* 
* Copyright (c) Bravarda Game Studio
* Little Prick Project 2017
*
*/
using UnityEngine;

public class CreditsButton : MonoBehaviour {

	private Animator creditsAnimator;
	public AudioClip clickSound;
	public AudioClip backSound;
	private AudioSource Click;

	private void Awake()
	{
		creditsAnimator = GetComponent<Animator>();
		Click = GetComponent<AudioSource>();
		Click.pitch = 0.5f;
	}
	public void OnCreditsClick()
	{
		if(!creditsAnimator.GetBool("GO"))
		{
			Click.Stop();
			Click.PlayOneShot(clickSound, 0.2f);
			creditsAnimator.SetBool("GO", true);
			creditsAnimator.SetBool("BACK", false);
		}
		else
		{
			Click.Stop();
			Click.PlayOneShot(backSound, 0.2f);
			creditsAnimator.SetBool("GO", false);
			creditsAnimator.SetBool("BACK", true);
		}

	}

	public void OnExitClick()
	{
		Click.PlayOneShot(backSound, 0.2f);
		Application.Quit();
	}
	
}
