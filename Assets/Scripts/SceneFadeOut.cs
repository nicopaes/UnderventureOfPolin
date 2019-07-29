/* 
* Copyright (c) Bravarda Game Studio
* Little Prick Project 2017
*
*/
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneFadeOut : MonoBehaviour
{
	#region Public Variables
	public bool GameReady;
	public bool LevelEnd;
	#endregion

	#region Private Variables
	private Animator sprite;
	#endregion

	#region Start and Awake
	private void Awake()
	{
		transform.localScale = Vector3.zero;
		GameReady = false;
		LevelEnd = false;
	}
	void Start () {
		sprite = GetComponent<Animator>();
	}

	#endregion
	
	#region Fixed-Update²
	void Update () {
		if(Input.anyKeyDown && SceneManager.GetActiveScene().name == "Animatic")
		{
			StartAnimation();
		}
	}
	#endregion

	#region Auxiliary Functions
	public void ChangeScene()
	{
		if (SceneManager.GetActiveScene().name == "Animatic")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		else if (SceneManager.GetActiveScene().name == "GoldLevel" && !LevelEnd)
		{
			SceneManager.LoadScene("GoldLevel");
		}
		else if(SceneManager.GetActiveScene().name == "GoldLevel" && LevelEnd)
		{
			SceneManager.LoadScene("Menu"); // Change this to Final Animatic !!!
		}
	}
	public void StartAnimation()
	{
		sprite.SetBool("Fade", true);
	}
	void ChangeGameReady()
	{
		GameReady = true;
	}
	#endregion
}
