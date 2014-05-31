using UnityEngine;
using System.Collections;

public class FaceGun : MonoBehaviour {

	public GameObject bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			GameObject o = Instantiate (bullet) as GameObject;
			o.transform.position = SteamVR_Camera.Instance.transform.position;
			o.transform.rotation = SteamVR_Camera.Instance.transform.rotation;
		}
	}
}
