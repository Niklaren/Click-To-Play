using UnityEngine;
using System.Collections;

public class ClickToReadListen : ClickToAct {
	
	public float openingTime = 1.0f;
	public AudioClip clip;
	public float clipVolume = 1.0f;
	
	public float timeToClipEnd = 1.0f;
	private float clipTimer = 0.0f;
	private bool isPlaying = false;

	public string text;
	
	public override void Update()
	{
		base.Update();
		if(isPlaying){ clipTimer += Time.deltaTime; }
		
		if(clipTimer > timeToClipEnd)
		{
			Cleanup();
		}
	}
	
	public override void DoClickToAct()
	{
		GetComponent<AudioSource>().PlayOneShot (clip, clipVolume);
		isPlaying = true;
		clipTimer = 0.0f;
	}
	
	public override void Cleanup()
	{
		base.Cleanup ();
		this.enabled = false;
	}
	protected override void SetInstruction()
	{
		SetInstructionString ("Click To " + text);
	}
}