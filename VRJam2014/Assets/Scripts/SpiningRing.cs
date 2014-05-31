using UnityEngine;
using System.Collections;

public class SpiningRing : MonoBehaviour {
	public float XRotation = 0.0f;
	public float YRotation = 0.0f;
	public float ZRotation = 0.0f;

	Vector3 targetEuler;

	Quaternion targetQuaterion; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		targetEuler.x += XRotation*Time.deltaTime;
		targetEuler.y += YRotation*Time.deltaTime;
		targetEuler.z += ZRotation*Time.deltaTime;

		//targetQuaterion = Quaternion.Euler(this.transform.rotation.eulerAngles.x + XRotation, this.transform.rotation.eulerAngles.y + YRotation, this.transform.rotation.eulerAngles.z + ZRotation);
		//transform.rotation = Quaternion.RotateTowards(this.transform.localRotation, targetQuaterion, Time.deltaTime * 100);

		transform.rotation = Quaternion.Euler(targetEuler);
	}
}
