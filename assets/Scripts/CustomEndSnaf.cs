using UnityEngine;
using System.Collections;

public class CustomEndSnaf : MonoBehaviour {

	public GameObject Up;
	public GameObject Down;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(){
		Up.SetActive (true);
		Down.SetActive (true);
	}
}
