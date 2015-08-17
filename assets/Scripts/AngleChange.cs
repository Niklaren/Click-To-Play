using UnityEngine;
using System.Collections;

public class AngleChange : MonoBehaviour {

	public GameObject player;
	private ClickToStep clickToStep;

	public float newHorizontalAngle;
	public float deltaHeight;

	// Use this for initialization
	void Start () {
		clickToStep = player.GetComponent<ClickToStep> ();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			Debug.Log ("AngleChange");
			clickToStep.enabled=true;
			//player.transform.Rotate(0, newHorizontalAngle, 0);
			//player.GetComponentInChildren<Camera>().transform.Rotate(0, -newHorizontalAngle, 0);
			newHorizontalAngle = newHorizontalAngle * Mathf.Deg2Rad;
			clickToStep.horizontalAngle = newHorizontalAngle;
			clickToStep.heightChange = deltaHeight;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
