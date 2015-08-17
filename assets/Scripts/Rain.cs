using UnityEngine;
using System.Collections;

public class Rain : MonoBehaviour {

	public GameObject rainPrefab;
	public Transform player; 
	public Vector3 rainSpawnOffset;

	public float rainDelay = 2.0f;

	private bool hasTriggered = false;

	private Color startSkyColor;
	public Color rainSkyColor;
	public Camera mainCam;
	public float skyFadeTime = 1.0f;
	private bool rainSpawned = false;

	public GameObject rainAudio;


	// Use this for initialization
	void Start () {
		startSkyColor = mainCam.backgroundColor;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(rainSpawned)
		{
			mainCam.backgroundColor = Color.Lerp(mainCam.backgroundColor, rainSkyColor, Time.deltaTime * skyFadeTime);
		}
	}

	void OnTriggerEnter(Collider trigger)
	{
		if(trigger.transform.tag == "Player")
		{
			if(hasTriggered == false)
			{
				hasTriggered = true;
				GameObject rainAudioObject = Instantiate(rainAudio, player.transform.position, Quaternion.Euler(Vector3.zero)) as GameObject;
				rainAudio.transform.parent = player;
				Invoke("SpawnRain", rainDelay);
			}
		}
	}

	private void SpawnRain()
	{
		Vector3 rainPos = player.transform.position;
		rainPos += rainSpawnOffset;
		GameObject rain = Instantiate(rainPrefab, rainPos, Quaternion.Euler(new Vector3(90,90,0))) as GameObject;
		rain.transform.parent = player;
		rainSpawned = true;

	}
	
}
