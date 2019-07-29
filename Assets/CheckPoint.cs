using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

	public Transform[] listOfCheckpoints;
	public SaveLoadGame loadGame;
	public int currentCheckpoint;

	private void Start()
	{
		currentCheckpoint = loadGame.CollectSavedValues();
		Debug.Log("The player new Checkpoint is: " + currentCheckpoint);
		if (currentCheckpoint != -1)
		{
			transform.position = listOfCheckpoints[currentCheckpoint].position;
			GetComponent<HookMovement>().Target = (Vector2)transform.position + new Vector2(0.1f, 0.1f);
			if (GetComponent<playerHealth>().HP < 2)
			{
				GetComponent<playerHealth>().TakeDamage(-1);
			}
			Destroy(listOfCheckpoints[currentCheckpoint].gameObject);
		}
	}
}
