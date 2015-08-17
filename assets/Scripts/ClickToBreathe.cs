using UnityEngine;
using System.Collections;

public class ClickToBreathe : ClickToAct {
	
	public float openingTime = 1.0f;
	public AudioClip breath;
	public float breathVolume = 1.0f;

	public float timeToBreathe = 1.0f;
	private float breatheTimer = 0.0f;
	private bool isBreathing = false;

	public override void Update()
	{
		base.Update();
		if(isBreathing){ breatheTimer += Time.deltaTime; }

		if(breatheTimer > timeToBreathe)
		{
			EndBreathing();
		}
	}
	
	public override void DoClickToAct()
	{
		GetComponent<AudioSource>().PlayOneShot (breath, breathVolume);
		isBreathing = true;
		breatheTimer = 0.0f;
	}
	
	private void EndBreathing()
	{
		base.Cleanup ();
		this.enabled = false;
	}
	protected override void SetInstruction()
	{
		SetInstructionString ("Click To Enjoy the Fresh Air");
	}
}