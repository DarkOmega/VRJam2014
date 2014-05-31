using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public Camera MyCamera; 

	// Use this for initialization
	void Start () {
		this.rigidbody.AddForce(-80,80,0);
	}
	
	// Update is called once per frame
	void Update () {
		MyCamera.transform.localEulerAngles.Set(this.transform.localEulerAngles);
	}
}
