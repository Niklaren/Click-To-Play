using UnityEngine;
using System.Collections;

public class ClickToDonate : ClickToAct {

	public AudioClip donationSound;
	public float donationSoundVolume;
	
	public float travelTime = 1.0f;
	private bool hasDoneFirstTween = false;

	public override void Update()
	{
		base.Update();

	}
	
	public override void DoClickToAct()
	{
		if(hasDoneFirstTween == false)
		{
			GetComponent<AudioSource>().PlayOneShot (donationSound, donationSoundVolume);
			Go.to(transform, travelTime, new GoTweenConfig().position(new Vector3(0, 2.8f, 0),true).setEaseType(GoEaseType.QuadInOut).onComplete(FinishFirstTween));
			Go.to(player.transform, travelTime, new GoTweenConfig().position(new Vector3(0, 2.8f, 0),true).setEaseType(GoEaseType.QuadInOut));
			hasTriggered = true;
		}
		else
		{
			GetComponent<AudioSource>().PlayOneShot (donationSound, donationSoundVolume);
			Go.to(transform, travelTime, new GoTweenConfig().position(new Vector3(0, 2.8f, 0),true).setEaseType(GoEaseType.QuadInOut).onComplete(OnComplete));
			Go.to(player.transform, travelTime, new GoTweenConfig().position(new Vector3(0, 2.8f, 0),true).setEaseType(GoEaseType.QuadInOut));
			SetInstructionString (" ");
			hasTriggered = true;
		}
	}

	private void FinishFirstTween(AbstractGoTween tween)
	{
		clickToStep.clickToInstruction.GetComponent<Renderer>().enabled = true;
		hasDoneFirstTween = true;
		hasTriggered = false;
		SetInstructionString ("   Click To \nBe Generous");
	}

	protected override void SetInstruction()
	{
		if(hasDoneFirstTween == false)
		{
			SetInstructionString ("Click To \nDonate");
		}
		else
		{
			SetInstructionString ("   Click To \nBe Generous");
		}
	}

	private void OnComplete(AbstractGoTween tween)
	{
		base.Cleanup ();
	}
}