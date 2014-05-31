using UnityEngine;
using System.Collections;

public class FaceBullet : MonoBehaviour {

	float spawnTime;
	// Use this for initialization
	void Start () {
		spawnTime = Time.time;
		rigidbody.velocity = SteamVR_Camera.Instance.offset.forward*3.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - spawnTime > 5.0f) {
			Destroy(gameObject);
		}
	}
}
