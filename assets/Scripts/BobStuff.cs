using UnityEngine;
using System.Collections;

public class BobStuff : MonoBehaviour {

	public float bobHeight = 1.0f;
	public float bobSpeed = 1.0f;

	private float bobTimer = 0.0f;
	private Vector3 startPos;

	// Use this for initialization
	void Start () {
		startPos = transform.position;

		bobSpeed += UnityEngine.Random.Range (-0.02f, 0.02f);
		bobTimer = UnityEngine.Random.Range (0.0f, 2.0f * Mathf.PI);

	}
	
	// Update is called once per frame
	void Update () {

		Vector3 newPos = transform.position;
		newPos.y = startPos.y + (Mathf.Sin (bobTimer) * bobHeight);

		transform.position = newPos;

		bobTimer += Time.deltaTime * bobSpeed;
		if(bobTimer >= 2.0f * Mathf.PI)
		{
			bobTimer = 0.0f;
		}
	}
}
