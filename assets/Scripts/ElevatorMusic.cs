using UnityEngine;
using System.Collections;

public class ElevatorMusic : MonoBehaviour {

	public AudioSource backingMusic;
	public float fadeSpeed = 1.0f;

	private bool hasBeenTriggered = false;

	private bool fadeOutBackingTrack = false;
	private bool fadeInBackingTrack = false;

	private float startBackingVolume = 1.0f;

	// Use this for initialization
	void Start () {
		startBackingVolume = backingMusic.volume;
	}
	
	// Update is called once per frame
	void Update () {
		if(hasBeenTriggered)
		{
			if(GetComponent<AudioSource>().isPlaying == false)
			{
				GetComponent<AudioSource>().Stop();
				FadeInBacking();
			}
		}

		if(fadeOutBackingTrack)
		{
			if(backingMusic.volume > 0.0f)
			{
				backingMusic.volume -= fadeSpeed * Time.deltaTime;
			}
		}

		if(fadeInBackingTrack)
		{
			if(backingMusic.volume < startBackingVolume)
			{
				backingMusic.volume += fadeSpeed * Time.deltaTime;
				if(backingMusic.volume > startBackingVolume)
				{
					backingMusic.volume = startBackingVolume;
				}
			}
		}
	}

    public void TriggerElevatorMusic()
	{
		FadeOutBacking ();
		GetComponent<AudioSource>().Play ();
		hasBeenTriggered = true;
	}

	private void FadeOutBacking()
	{
		fadeInBackingTrack = false;
		fadeOutBackingTrack = true;
	}

	private void FadeInBacking()
	{
		fadeOutBackingTrack = false;
		fadeInBackingTrack = true;
	}
}
