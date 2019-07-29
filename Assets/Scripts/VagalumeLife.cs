/* 
* Copyright (c) Bravarda Game Studio
* John K. Paul Project 2017
*
*/
using UnityEngine;

public class VagalumeLife : MonoBehaviour {

	#region Public Variables
	public GameObject HealParticles;
	[Space]
	public SaveLoadGame saveGame;

	#endregion

	#region Private Variables
	private int collectedcheckPoint;
	#endregion 

	#region Start and Awake
	void Start () {
		
	}

	#endregion
	
	#region Fixed-Update²
	void Update () {
		
	}
	#endregion


	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.transform.CompareTag("Player"))
		{
			collectedcheckPoint = saveGame.CollectSavedValues();
			collectedcheckPoint += 1;

			Debug.Log("The checkpoint was saved now: " + collectedcheckPoint);

			SaveLoadGame.SaveCheckpoint(collectedcheckPoint);
			if(collision.transform.GetComponent<playerHealth>() == true)
			{
				collision.transform.GetComponent<playerHealth>().TakeDamage(-1);
				Instantiate(HealParticles, transform.position,Quaternion.identity);
				Destroy(this.gameObject);
			}
		}
	}
	#region Auxiliary Functions

	#endregion
}
