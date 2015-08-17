using UnityEngine;
using System.Collections;

public class ClickToJump : ClickToAct {

	private bool isJumping = false;
	public float jumpTime = 1.0f;


	// Update is called once per frame
	public override void Update () {
			
	}

	public override void DoClickToAct()
	{
		if(isJumping == false)
		{
				//Bob 
				isJumping = true;
				//clickToInstruction.renderer.enabled = false;
				var headPopPoints = new Vector3[] { new Vector3( 0, 0, 0 ), new Vector3( 0, 1, 0), new Vector3( 0, 0, 0 )};
				var path = new GoSpline( headPopPoints );
				path.closePath();
				
				GoTweenConfig stepConfig = new GoTweenConfig().positionPath(path,true).onComplete(OnJumpComplete);
				
				stepConfig.setEaseType(GoEaseType.QuadOut);
				Go.to( player.transform, jumpTime, stepConfig);
		}
	}

	private void OnJumpComplete(AbstractGoTween tween)
	{
		isJumping = false;
		base.Cleanup ();
	}
	protected override void SetInstruction()
	{
		SetInstructionString ("Click To Instruction");
	}
}
