using UnityEngine;
using System.Collections;

public class MainMenuFadeInOut : MonoBehaviour {

	public GameObject fader;

	public bool hasFadedIn = false;
	public float fadeSpeed = 0.5f;

	bool shouldFadeOut = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(hasFadedIn == false)
		{
			Color fadeColor = fader.GetComponent<Renderer>().material.color;
			fadeColor.a -= fadeSpeed * Time.deltaTime;
			fader.GetComponent<Renderer>().material.color = fadeColor;


			if(fader.GetComponent<Renderer>().material.color.a <= 0.0f)
			{
				hasFadedIn = true;
			}

		}


		if(shouldFadeOut)
		{
			Color fadeColor = fader.GetComponent<Renderer>().material.color;
			fadeColor.a += fadeSpeed * Time.deltaTime;
			fader.GetComponent<Renderer>().material.color = fadeColor;
		}

	}

	public void FadeOut()
	{
		shouldFadeOut = true;
	}
}
