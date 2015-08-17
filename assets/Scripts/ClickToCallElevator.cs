using UnityEngine;
using System.Collections;

public class ClickToCallElevator : ClickToAct {

	public float callTime = 1.0f;
	public ButtonPush buttonPush;
	//public AudioClip Elevator;
	public GameObject doorA;
	public GameObject doorB;

	public AudioClip doorOpen;
	public float doorOpenVolume = 1.0f;
	
	public override void Update()
	{
		base.Update();
	}

	public override void DoClickToAct()
	{
		//ScaleTweenProperty DoorScale = new blabla
		buttonPush.Push ();
		var elevatorPath = new Vector3[] { new Vector3( 0, 0, 0 ), new Vector3( 0, 2.4f, 0 )};
		var path = new GoSpline( elevatorPath );
		//path.closePath();
		
		GoTweenConfig stepConfig = new GoTweenConfig().positionPath(path,true).onComplete(OpenDoors);
		
		stepConfig.setEaseType(GoEaseType.QuadInOut);
		Go.to( transform.parent.gameObject.transform, callTime, stepConfig);
	}

	public void OpenDoors(AbstractGoTween tween)
	{
		Go.to(doorA.transform, 0.7f, new GoTweenConfig().position(new Vector3(0, 0, -0.28f),true).setEaseType(GoEaseType.QuadInOut).onComplete(OnComplete));
		Go.to(doorB.transform, 0.7f, new GoTweenConfig().position(new Vector3(0, 0, 0.28f),true).setEaseType(GoEaseType.QuadInOut));

		GetComponent<AudioSource>().PlayOneShot (doorOpen, doorOpenVolume);
	}

	private void OnComplete(AbstractGoTween tween)
	{
		base.Cleanup ();
	}
	protected override void SetInstruction()
	{
		SetInstructionString ("Click To Push Button");
	}
}