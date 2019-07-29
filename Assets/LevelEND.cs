/* 
* Copyright (c) Bravarda Game Studio
* Little Prick Project 2017
*
*/
using UnityEngine;

public class LevelEND : MonoBehaviour
{
	public SceneFadeOut fadeOut;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		fadeOut.LevelEnd = true;
		fadeOut.StartAnimation();
	}
}
