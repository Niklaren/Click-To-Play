using UnityEngine;
using System.Collections;

public abstract class ClickToAct : MonoBehaviour {

	public GameObject player;
	protected ClickToStep clickToStep;

	protected bool hasTriggered = false;
	protected bool isInTrigger = false;

	public Transform instructionTransform;
	public float timeForTextFadeOut = 1.0f;

	// Use this for initialization
	public void Start () {
		clickToStep = player.GetComponent<ClickToStep> ();
	}
	
	// Update is called once per frame
	public virtual void Update () {
		if(isInTrigger)
		{
			if((hasTriggered == false) && (clickToStep.IsStepping() == false))
			{
				SetInstruction();
				clickToStep.enabled = false;
				if(Input.GetMouseButtonDown(0))
				{
					if(clickToStep.clickToInstruction.gameObject.GetComponent<Renderer>().isVisible)
					{
						clickToStep.clickToInstruction.GetComponent<Renderer>().enabled = false;
						ClickToActBegin();
					}
				}
			}
		}
	}

	private void ClickToActBegin()
	{
		hasTriggered = true;
		DoClickToAct ();
	}

	public abstract void DoClickToAct ();


	public virtual void Cleanup ()
	{
		clickToStep.enabled = true;
		clickToStep.clickToInstruction.GetComponent<Renderer>().enabled = false;
		clickToStep.ResetStringInstruction ();
	}

	private void OnTriggerEnter(Collider collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			isInTrigger = true;

		}
	}


	protected void SetInstructionString(string newString)
	{
		clickToStep.clickToInstruction.transform.position = instructionTransform.position;
		clickToStep.clickToInstruction.transform.rotation = instructionTransform.rotation;
		clickToStep.clickToInstruction.transform.localScale = instructionTransform.transform.localScale;
		clickToStep.clickToInstruction.text = newString;
		clickToStep.clickToInstruction.GetComponent<Renderer>().enabled = true;
	}
	protected abstract void SetInstruction();
}
