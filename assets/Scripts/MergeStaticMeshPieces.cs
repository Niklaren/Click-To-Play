using UnityEngine;
using System.Collections;

//Attatch to an object that has meshes you want to merge. Attatch an instance of the Meshmerger script, which should be attatched to an empty somewhere.
public class MergeStaticMeshPieces : MonoBehaviour {

	public string mergedMeshObjectName;
	private MeshMerger mergedMeshObject; //set in awake with .find()

	public MeshFilter[] meshesToMerge;

	// Use this for initialization
	void Awake ()
	{
		mergedMeshObject = GameObject.Find(mergedMeshObjectName).GetComponent("MeshMerger") as MeshMerger;
		if(mergedMeshObject == null)
		{
			Debug.LogError("Can't find merged mesh object in MergeStaticMeshPeices.cs, Start()");
		}

		foreach(MeshFilter filter in meshesToMerge)
		{
			mergedMeshObject.AddMeshFilterToMerge(filter);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
