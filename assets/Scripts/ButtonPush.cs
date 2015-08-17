using UnityEngine;
using System.Collections;

public class ButtonPush : MonoBehaviour {

	public float timeForButtonPush = 1.0f;
	public Vector3 buttonPushVector;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Push()
	{
		var pushPoints = new Vector3[] { new Vector3( 0, 0, 0 ), buttonPushVector};
		var path = new GoSpline( pushPoints );
		path.closePath();
		
		GoTweenConfig pushConfig = new GoTweenConfig ().positionPath (path, true);
		
		pushConfig.setEaseType(GoEaseType.QuadInOut);
		Go.to( transform, timeForButtonPush, pushConfig);
	}
}
