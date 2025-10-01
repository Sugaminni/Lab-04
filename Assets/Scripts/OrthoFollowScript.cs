using UnityEngine;
using System.Collections;

public class OrthoFollowScript : MonoBehaviour {

	public Transform thingToFollow;
	public Vector3 offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = thingToFollow.transform.position + offset;
	}
}
