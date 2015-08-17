using UnityEngine;
using System.Collections;

public class FadeWhiteOnSceneStart : MonoBehaviour {

	bool hasFadedIn = false;
	public float fadeSpeed = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(hasFadedIn == false)
		{
			Color newColor = GetComponent<Renderer>().material.color;
			newColor.a -= fadeSpeed * Time.deltaTime;
			GetComponent<Renderer>().material.color = newColor;

			if(GetComponent<Renderer>().material.color.a <= 0.0f)
			{
				hasFadedIn = true;
			}
		}
	}
}
