using UnityEngine;
using System.Collections;

public class FaceGun : MonoBehaviour {

	public GameObject bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
		{
			GameObject o = Instantiate (bullet) as GameObject;
			if (SteamVR_Camera.Instance.offset)
			{
				o.transform.position = SteamVR_Camera.Instance.offset.position;
				o.transform.rotation = SteamVR_Camera.Instance.offset.rotation;
			}
			else
			{
				o.transform.position = SteamVR_Camera.Instance.transform.position;
				o.transform.rotation = SteamVR_Camera.Instance.transform.rotation;
			}
			GameMgr.Instance.TookShot();
		}
	}
}
