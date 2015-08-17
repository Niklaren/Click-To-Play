using UnityEngine;
using System.Collections;

public class ClickToGoUp : ClickToAct {

	private float ascendTime = 10.0f;
	private float ascendHeight = 20.0f;

	public float fadeSpeed = 1.0f;

	private bool baws = false;

	public GameObject fadePlane;

	// Update is called once per frame
	public override void Update () {
		base.Update ();
		if(baws)
		{
			Color newColor = fadePlane.GetComponent<Renderer>().material.color;
			newColor.a += Time.deltaTime * fadeSpeed;
			fadePlane.GetComponent<Renderer>().material.color = newColor;
		}
	}

	public override void DoClickToAct()
	{
		Go.to (player.transform, ascendTime, new GoTweenConfig ().position (new Vector3 (0, ascendHeight, 0), true).setEaseType (GoEaseType.QuadInOut).onComplete(OnFloatComplete));

		baws = true;
	}

	private void OnFloatComplete(AbstractGoTween tween)
	{
		base.Cleanup ();
	}
	protected override void SetInstruction()
	{
		SetInstructionString ("Click To Dream");
	}
}
