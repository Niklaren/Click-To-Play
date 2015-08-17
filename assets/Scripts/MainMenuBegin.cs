using UnityEngine;
using System.Collections;

public class MainMenuBegin : MonoBehaviour {

	public string mainGameScene = "MainScene";
	public float sceneSwapDelay = 1.0f;
	public MainMenuFadeInOut fader;

	public AudioSource music;
	public float musicFadeSpeed = 1.0f;

	bool fadeOutMusic = false;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			if(fader.hasFadedIn)
			{
				Invoke ("SwapScene", sceneSwapDelay);
				fader.FadeOut();

				fadeOutMusic = true;
			}
		}

		if(fadeOutMusic)
		{
			music.volume -= musicFadeSpeed * Time.deltaTime;
		}
	
	}

	void SwapScene()
	{
		Application.LoadLevel(mainGameScene);
	}
}
