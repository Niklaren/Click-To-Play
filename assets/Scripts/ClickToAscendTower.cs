using UnityEngine;
using System.Collections;

public class ClickToAscendTower  : ClickToAct {
	
	public float jumpTime = 1.0f;
	public float jumpHeight = 1.0f; 
	public float jumpLength = 1.5f;

	public float jumpHitVerticalOffset = 1.0f;

	public AudioClip landSound;
	public float landVolume = 1.0f;

	public string text;

	public GameObject nextPlatform;

	public void Start()
	{
		base.Start ();
	}
	
	public override void Update()
	{

		base.Update();

	}
	
	public override void DoClickToAct()
	{
		clickToStep.enabled = false;
		Vector3 nextPosition = new Vector3(nextPlatform.transform.position.x, nextPlatform.transform.position.y + jumpHitVerticalOffset, nextPlatform.transform.position.z);

		Vector3 jumpCenter;
		jumpCenter = player.transform.position + nextPlatform.transform.position;
		jumpCenter /= 2;
		jumpCenter.y += jumpHeight * Vector3.Distance(player.transform.position, nextPosition);
		//jumpCenter;
		Vector3[] jumpVecs = new Vector3[]{player.transform.position, jumpCenter ,new Vector3(nextPlatform.transform.position.x, nextPlatform.transform.position.y + jumpHitVerticalOffset, nextPlatform.transform.position.z)};
		GoSpline path = new GoSpline (jumpVecs);
		//path.closePath ();

		GoTweenConfig jumpConfig = new GoTweenConfig().positionPath(path,false).onComplete(JumpCleanup);
		jumpConfig.setEaseType (GoEaseType.SineInOut);

		Go.to(player.transform, jumpTime, jumpConfig);

		//Invoke ("PlayLandAudio", jumpTime - 0.2f);
	}
	
	private void JumpCleanup(AbstractGoTween tween)
	{
		base.Cleanup ();
	}
	protected override void SetInstruction()
	{
		SetInstructionString ("Click To " + text);
		clickToStep.clickToInstruction.transform.LookAt (player.transform.position);
		clickToStep.clickToInstruction.transform.Rotate(new Vector3(0, 180, 0));
	}
	
	private void PlayLandAudio()
	{
		GetComponent<AudioSource>().PlayOneShot (landSound, landVolume);
	}
}