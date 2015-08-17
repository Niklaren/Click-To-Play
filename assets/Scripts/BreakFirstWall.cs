using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BreakFirstWall : ClickToAct {

	public List<Rigidbody> blocksToShoot = new List<Rigidbody>();
	public float maxForceToApply = 10;

	public string message;

	public AudioClip wallBreak;
	public float wallBreakVolume = 1.0f;

	public GameObject explosion;

	// Use this for initialization
	void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
	}

	public override void DoClickToAct()
	{
		foreach(Rigidbody body in blocksToShoot)
		{
			body.AddForce(new Vector3(UnityEngine.Random.Range(0, maxForceToApply)/4,UnityEngine.Random.Range(-maxForceToApply, maxForceToApply),UnityEngine.Random.Range(-maxForceToApply, maxForceToApply)));
			GetComponent<AudioSource>().PlayOneShot(wallBreak, wallBreakVolume);
		}

		Vector3 explosionPoint = transform.position;
		explosionPoint.y += 2.0f;
		Instantiate(explosion, explosionPoint, transform.rotation);

		base.Cleanup ();
	}

	protected override void SetInstruction()
	{
		SetInstructionString (message);
	}
}
