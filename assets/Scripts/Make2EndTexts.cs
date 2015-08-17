using UnityEngine;
using System.Collections;

public class Make2EndTexts : MonoBehaviour {

	public Transform goUpPos;
	public Transform goDownPos;

	public TextMesh goUpText;
	public TextMesh goDownText;

	public GameObject player;
	public float ascendTime = 10;
	public float ascendHeight = 10;

	protected bool isInTrigger = false;

	private bool goingUp = false;
	private bool goingDown = false;

	public GameObject fadePlane;
	public float fadeSpeed = 0.25f;

	public float timeToReset = 3.0f;

	public AudioSource finalWindRush;
	public float rampUpWindSpeed = 1.0f;

	public AudioSource musicAudio;
	public float audioFadeSpeed = 0.5f;

	// Use this for initialization
	void Start () {
		finalWindRush.volume = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if((goingUp == false) && (goingDown == false))
		{
			if(isInTrigger)
			{
				player.GetComponent<ClickToStep>().enabled = false;
				if(Input.GetMouseButtonDown(0))
				{
					if(goUpText.GetComponent<Renderer>().isVisible)
					{
						Go.to (player.transform, ascendTime, new GoTweenConfig ().position (new Vector3 (0, ascendHeight, 0), true).setEaseType (GoEaseType.QuadInOut));
						goingUp = true;
						goUpText.GetComponent<Renderer>().enabled = false;
						goDownText.GetComponent<Renderer>().enabled = false;
						Invoke("Finish", timeToReset + 3.0f);
					}
					else if(goDownText.GetComponent<Renderer>().isVisible)
					{
						goingDown = true;
						finalWindRush.Play();
						player.GetComponent<Rigidbody>().isKinematic = false;
						player.GetComponent<Rigidbody>().useGravity = true;
						player.GetComponent<Rigidbody>().AddForce (new Vector3 (0, 120, -100));

						goUpText.GetComponent<Renderer>().enabled = false;
						goDownText.GetComponent<Renderer>().enabled = false;
						Invoke("Finish", timeToReset);
					}
				}
			}
		}

		if((goingUp) || (goingDown))
		{
			if(goingDown)
			{
				RampUpWind();
				FadeOutAudio();
			}
			if(goingUp)
			{
				FadeOutAudio();
			}
			Color newColor = fadePlane.GetComponent<Renderer>().material.color;
			newColor.a += Time.deltaTime * fadeSpeed;
			fadePlane.GetComponent<Renderer>().material.color = newColor;
		}
	}

	private void FadeOutAudio()
	{
		musicAudio.volume -= audioFadeSpeed * Time.deltaTime;
	}

	void OnTriggerEnter(Collider collide)
	{
		if(collide.tag == "Player")
		{
			isInTrigger = true;

			goUpText.GetComponent<Renderer>().enabled = true;
			goUpText.transform.position = goUpPos.transform.position;
			goUpText.transform.rotation = goUpPos.transform.rotation;
			goUpText.transform.localScale = goUpPos.transform.localScale;

			goDownText.GetComponent<Renderer>().enabled = true;
			goDownText.transform.position = goDownPos.transform.position;
			goDownText.transform.rotation = goDownPos.transform.rotation;
			goDownText.transform.localScale = goDownPos.transform.localScale;
		}
	}

	private void Finish()
	{
		Application.LoadLevel ("MainMenuScene");
	}

	private void RampUpWind()
	{
		finalWindRush.volume += Time.deltaTime * rampUpWindSpeed;
	}
}
