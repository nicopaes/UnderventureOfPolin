using UnityEngine.SceneManagement;
using UnityEngine;

public class SaveLoadGame : MonoBehaviour {

	//these variables will send the values in.
	public static int currentCheckpoint = -1;

	//these vaibles will collect the saved values
	public int collectCheckpoint;
	public static bool firstTimeloading = true;

	void Awake()
	{
		if (firstTimeloading)
		{
			Save();
			firstTimeloading = false;
		}
	}
	private void OnLevelWasLoaded(int level)
	{
		CollectSavedValues();
	}
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.G))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	public static void Save()
	{   //this is the save function
		// the part in quotations is what the "bucket" is that holds your variables value
		// the second one in quotations is the value you want saved, you can also put a variable there instead
		Debug.Log("Save on first load");
		PlayerPrefs.SetInt("currentCheckpoint", currentCheckpoint);
		PlayerPrefs.Save();
	}
	public static void SaveCheckpoint(int Checkpoint)
	{
		PlayerPrefs.SetInt("currentCheckpoint", Checkpoint);
		PlayerPrefs.Save();
	}

	public int CollectSavedValues()
	{
		collectCheckpoint = PlayerPrefs.GetInt("currentCheckpoint");
		Debug.Log("The current checkpoint: " + collectCheckpoint);
		return collectCheckpoint;
		
	}
}
