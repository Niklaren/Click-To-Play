using UnityEngine;
using System.Collections;

public class ClickToStep : MonoBehaviour {
	
	public float stepLength;
	public float stepTime;
	public float stepBobHeight;

	public float horizontalAngle;
	public float heightChange;
	
	private bool isStepping = false;
	private bool isLeft = false;
	
	public TextMesh clickToInstruction;
	public string instruction = "Click To Step";

	public float timeForTextFadeOut = 1.0f;
	
	
	// Use this for initialization
	void Start () {
		ResetStringInstruction ();
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
		DoClickToStep ();
		
	}

	private void DoClickToStep()
	{
		if(isStepping == false)
		{
			if(Input.GetMouseButtonDown(0))
			{
				float xdistance = -(stepLength*Mathf.Cos(horizontalAngle));
				float zdistance = (stepLength*Mathf.Sin(horizontalAngle));

				//Bob 
				isStepping = true;
				clickToInstruction.GetComponent<Renderer>().enabled = false;
				var headPopPoints = new Vector3[] { new Vector3( 0, 0, 0 ), new Vector3( xdistance/2, stepBobHeight, zdistance/2 ), new Vector3( xdistance, heightChange, zdistance )};
				var path = new GoSpline( headPopPoints );
				path.closePath();
				
				GoTweenConfig stepConfig = new GoTweenConfig().positionPath(path,true).onComplete(OnStepComplete);
				
				stepConfig.setEaseType(GoEaseType.QuadInOut);
				Go.to( transform, stepTime, stepConfig);
				
				
			}
		}
	}
	
	private void OnStepComplete(AbstractGoTween tween)
	{
		isStepping = false;
		//clickToInstruction.renderer.enabled = true;
	}

	public void ResetStringInstruction()
	{
		clickToInstruction.text = instruction;
	}

	public bool IsStepping()
	{
		return isStepping;
	}
}
