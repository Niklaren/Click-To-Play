using UnityEngine;
using System.Collections;

public class ClicktoUseElevator : ClickToAct {
	
	public float rideTime = 8.0f;
	public float timeToSpin = 2.0f;
	public float spinTime = 4.0f;
	private float timeToSpinTimer = 0.0f;
	public float delayStartTime = 0.5f;
	private bool hasStarted = false;
	public ButtonPush elevatorButton;
	public Transform appreciateMusicTransform;

	private bool isOnMusicBit = false;
	private float musicClickDismissalDelayTimer = 0.0f;
	private float musicClickDismissalDelayTime = 0.5f;

	public GameObject doorA;
	public GameObject doorB;

	public AudioClip doorOpen;
	public float doorOpenVolume = 1.0f;

	public ElevatorMusic elevatorMusic;

	//public AudioClip Elevator;?
	
	public override void Update()
	{
		base.Update();

		if(hasStarted)
		{
			timeToSpinTimer += Time.deltaTime;
		}
		if(timeToSpinTimer > timeToSpin)
		{
			SpinElevator();
			hasStarted = false;
			timeToSpinTimer = 0.0f;
		}

		if(isOnMusicBit)
		{
			musicClickDismissalDelayTimer += Time.deltaTime;
			if((Input.GetMouseButtonDown(0)) && (musicClickDismissalDelayTimer > musicClickDismissalDelayTime))
			{
				//clickToStep.clickToInstruction.renderer.enabled = false;
				SetInstructionString (" ");
			}
		}
	}
	
	public override void DoClickToAct()
	{
		Go.to(doorA.transform, 0.3f, new GoTweenConfig().position(new Vector3(0, 0, 0.28f),true).setEaseType(GoEaseType.QuadInOut));
		Go.to(doorB.transform, 0.3f, new GoTweenConfig().position(new Vector3(0, 0, -0.28f),true).setEaseType(GoEaseType.QuadInOut));
		elevatorButton.Push ();
		SetInstruction2 ();
		Invoke ("StartTweenDown", delayStartTime);

	}

	private void StartTweenDown()
	{
		elevatorMusic.TriggerElevatorMusic();
		hasStarted = true;
		Go.to(transform.parent.transform, rideTime, new GoTweenConfig().position(new Vector3(0, -57.5f, 0),true).setEaseType(GoEaseType.QuadInOut).onComplete(OpenDoors));
		Go.to(player.transform, rideTime, new GoTweenConfig().position(new Vector3(0, -57.5f, 0),true).setEaseType(GoEaseType.QuadInOut));
	}

	public void SpinElevator()
	{
		RotationTweenProperty rotationProperty = new RotationTweenProperty (new Vector3 (0, -180, 0), true, true);

		GoTweenConfig rotConfig = new GoTweenConfig ().addTweenProperty (rotationProperty);
		
		rotConfig.setEaseType(GoEaseType.QuadInOut);

		//Go.to( player.transform, rideTime, rotConfig);
		Go.to( transform.parent.gameObject.transform, spinTime, rotConfig);
	}

	public void OpenDoors(AbstractGoTween tween)
	{
		Go.to(doorA.transform, 0.7f, new GoTweenConfig().position(new Vector3(0, 0, 0.28f),true).setEaseType(GoEaseType.QuadInOut).onComplete(OnRideComplete));
		Go.to(doorB.transform, 0.7f, new GoTweenConfig().position(new Vector3(0, 0, -0.28f),true).setEaseType(GoEaseType.QuadInOut));
		
		GetComponent<AudioSource>().PlayOneShot (doorOpen, doorOpenVolume);
	}
	
	private void OnRideComplete(AbstractGoTween tween)
	{
		base.Cleanup ();
	}
	protected override void SetInstruction()
	{
		SetInstructionString ("Click To \nPush Button");
	}
	protected void SetInstruction2()
	{
		isOnMusicBit = true;
		instructionTransform = appreciateMusicTransform;
		SetInstructionString ("Click To Appreciate Music");
	}
}