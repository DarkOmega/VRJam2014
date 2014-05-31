using UnityEngine;
using System.Collections;

public class KeyboardTranslation : MonoBehaviour {

	float movementSpeed = 1.0f;
	SteamVR_Camera vrCam;

	// Use this for initialization
	void Start () {
		vrCam = GetComponent<SteamVR_Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 deltaPos = Vector3.zero;

		if (Input.GetKey (KeyCode.A)) 
		{
			deltaPos.x -= movementSpeed;
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			deltaPos.x += movementSpeed;
		}
		if (Input.GetKey (KeyCode.W)) 
		{
			deltaPos.z += movementSpeed;
		}
		if (Input.GetKey (KeyCode.S)) 
		{
			deltaPos.z -= movementSpeed;
		}
		if (Input.GetKey (KeyCode.E)) 
		{
			deltaPos.y += movementSpeed;
		}
		if (Input.GetKey (KeyCode.C)) 
		{
			deltaPos.y -= movementSpeed;
		}

		deltaPos *= Time.deltaTime;
		if(vrCam.offset != null){
		deltaPos = vrCam.offset.rotation * deltaPos;
		}
		else{
			deltaPos = vrCam.transform.rotation * deltaPos;
		}

		transform.position += deltaPos;
	}
}
