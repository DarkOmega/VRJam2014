using UnityEngine;
using System.Collections;

public class FirstPersonBullet : MonoBehaviour {
	bool AmILaunched;
	public int LaunchSpeed;
	public SteamVR_Camera MyCamera;
	// Use this for initialization
	void Start () {
		AmILaunched = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && !AmILaunched){
			LaunchMe();
			AmILaunched = true;
		}
	}

	void LaunchMe(){
		//this.rigidbody.AddForce(MyCamera.transform.rotation.x * LaunchSpeed, MyCamera.transform.rotation.y, MyCamera.transform.rotation.z);
		//this.rigidbody.velocity = MyCamera.offset.forward * 10.0f;
		this.rigidbody.AddRelativeForce(MyCamera.offset.forward * 10.0f);
		Debug.Log("Farts!");
	}
}
