using UnityEngine;
using System.Collections;

public class ClickToJumpGap : ClickToAct {
	
	public float jumpGapTime = 1.0f;
	public float jumpHeight = 1.0f; 
	public float jumpLength = 1.5f;

	public AudioClip landSound;
	public float landVolume = 1.0f;
	public float timeTillPlayLand = 0.8f;

	
	public override void Update()
	{
		base.Update();
	}
	
	public override void DoClickToAct()
	{
		
		var jumpPath  = new Vector3[] { new Vector3( 0, 0, 0 ), new Vector3( -jumpLength/2, jumpHeight, 0), new Vector3( -jumpLength, 0, 0 )};
		var path = new GoSpline( jumpPath );
		path.closePath();

		//GoTweenConfig stepConfig = new GoTweenConfig().positionPath(path,true).onComplete(OnJumpComplete);
		GoTweenConfig jumpConfig = new GoTweenConfig().positionPath(path,true).onComplete(JumpGapCleanup);
		
		jumpConfig.setEaseType(GoEaseType.QuadInOut);
		Go.to( player.transform, jumpGapTime, jumpConfig);
		Invoke ("PlayLandAudio", timeTillPlayLand);
	}
	
	private void JumpGapCleanup(AbstractGoTween tween)
	{

		base.Cleanup ();
	}
	protected override void SetInstruction()
	{
		SetInstructionString ("Click To Leap");
	}

	private void PlayLandAudio()
	{
		GetComponent<AudioSource>().PlayOneShot (landSound);
	}
}