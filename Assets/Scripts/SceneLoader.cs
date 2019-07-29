using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {


	public SceneFadeOut fadeOut;
	public Text click2Play;
	public Image barBar;
	public Image fillBar;
	[Space]
	public bool loadReady;

	//[SerializeField]
	///private bool loadScene = false;
	private AsyncOperation async;
	// Updates once per frame
	void Update()
	{
		if(loadReady)
		{
			click2Play.enabled = true;
			if(Input.anyKeyDown)
			{
				fadeOut.StartAnimation();
				StartCoroutine(NextSceneWithDelay(1.2f));
			}
		}
		// If the player has pressed the space bar and a new scene is not loading yet...
		/*
		if (Input.GetKeyUp(KeyCode.Space) && loadScene == false)
		{

			// ...set the loadScene boolean to true to prevent loading a new scene more than once...
			loadScene = true;

			// ...change the instruction text to read "Loading..."
			//loadingText.text = "Loading...";

			// ...and start a coroutine that will load the desired scene.
			StartCoroutine(LoadNewScene());

		}

		// If the new scene has started loading...
		/*if (loadScene == true)
		{

			// ...then pulse the transparency of the loading text to let the player know that the computer is still working.
			loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));

		}*/

	}

	public void StarSceneLoad()
	{
		//SceneManager.LoadScene("GoldLevel");
		//fadeOut.StartAnimation();		
		if(async == null)
			StartCoroutine(LoadNewScene());
		barBar.enabled = true;
	}


	// The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
	IEnumerator LoadNewScene()
	{

		// This line waits for 3 seconds before executing the next line in the coroutine.
		// This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
		yield return new WaitForSeconds(2);

		// Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
		async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1); //Application.LoadLevelAsync(scene);
		async.allowSceneActivation = false;

		// While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
		while (!async.isDone)
		{		
			if(async.progress > 0.7f)
			{
				loadReady = true;
			}
			//loadingText.text = async.progress.ToString();
			fillBar.fillAmount = async.progress + 0.1f;
			yield return null;
		}
	}
	IEnumerator NextSceneWithDelay(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		async.allowSceneActivation = true;
	}
}
