using UnityEngine;
using System.Collections;

public class ClickToGoDown : ClickToAct {

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
		baws = true;
		player.GetComponent<Rigidbody>().isKinematic = false;
		player.GetComponent<Rigidbody>().useGravity = true;
		player.GetComponent<Rigidbody>().AddForce (new Vector3 (0, 5, 5));
	}

	private void OnFloatComplete(AbstractGoTween tween)
	{
		base.Cleanup ();
	}
	protected override void SetInstruction()
	{
		SetInstructionString ("Click To Wake Up");
	}
}
