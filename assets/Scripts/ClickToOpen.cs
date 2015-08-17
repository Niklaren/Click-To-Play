using UnityEngine;
using System.Collections;

public class ClickToOpen : ClickToAct {

	public float openingTime = 1.0f;

	public AudioClip doorOpenSound;
	public float doorOpenSoundVolume = 1.0f;
	
	public override void Update()
	{
		base.Update();
	}

	public override void DoClickToAct()
	{

		RotationTweenProperty rotationProperty = new RotationTweenProperty (new Vector3 (0, -90, 0), true, true);
		
		GoTweenConfig config = new GoTweenConfig();
		config.addTweenProperty( rotationProperty );
		
		var tween = new GoTween( transform, openingTime, config, OnOpenComplete );
		Go.addTween (tween);

		GetComponent<AudioSource>().PlayOneShot (doorOpenSound, doorOpenSoundVolume);
	}

	private void OnOpenComplete(AbstractGoTween tween)
	{
		base.Cleanup ();
	}
	protected override void SetInstruction()
	{
		SetInstructionString ("Click To Open");
	}
}
