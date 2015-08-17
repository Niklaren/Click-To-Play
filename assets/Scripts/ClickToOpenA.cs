using UnityEngine;
using System.Collections;

public class ClickToOpenA : ClickToAct {

	float openTime = 0.5f;

	public override void Update()
	{
		base.Update();
	}
	
	public override void DoClickToAct()
	{
		
		var doorMove  = new Vector3[] { new Vector3( 0, 0, 0 ), new Vector3( 0, 0, -0.25f), new Vector3( 0, 0, -0.5f)};
		var path = new GoSpline( doorMove );
		path.closePath();

		GoTweenConfig doorConfig = new GoTweenConfig().positionPath(path,true).onComplete(DoorCleanup);
		
		doorConfig.setEaseType(GoEaseType.QuadInOut);
		Go.to( transform, openTime, doorConfig);
	}

	private void DoorCleanup(AbstractGoTween tween)
	{
		base.Cleanup ();
	}
	protected override void SetInstruction()
	{
		SetInstructionString ("Click To Open");
	}

	private void OnTriggerExit(Collider other)
	{
		var doorMove  = new Vector3[] { new Vector3( 0, 0, 0 ), new Vector3( 0, 0, 0.25f), new Vector3( 0, 0, 0.5f)};
		var path = new GoSpline( doorMove );
		path.closePath();
		
		GoTweenConfig doorConfig = new GoTweenConfig().positionPath(path,true).onComplete(DoorCleanup);
		
		doorConfig.setEaseType(GoEaseType.QuadInOut);
		Go.to( transform, openTime, doorConfig);
	}
}