﻿using UnityEngine;
using System.Collections;

public class FaceBullet : MonoBehaviour {

	float spawnTime;
	bool doomed = false;

	// Use this for initialization
	void Start () {
		spawnTime = Time.time;
		if (SteamVR_Camera.Instance.offset != null)
			rigidbody.velocity = SteamVR_Camera.Instance.offset.forward*3.0f;
		else
			rigidbody.velocity = SteamVR_Camera.Instance.transform.forward*3.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - spawnTime > 5.0f) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision c)
	{
		if (doomed)
			return;
		doomed = true;
		spawnTime = Time.time + .45f - 5.0f;
		GetComponent<Animator> ().Play ("Fade");
		//GetComponent<Animator> ().speed = 4.0f;
		rigidbody.isKinematic = true;
		collider.enabled = false;
		audio.Play ();
		//Destroy (gameObject);
		if (c.rigidbody) {
			RaycastHit[] hits = Physics.RaycastAll(c.rigidbody.position, Vector3.up);
			foreach (RaycastHit hit in hits)
			{
				if (hit.rigidbody)
					hit.rigidbody.WakeUp();
			}
		}
	}
}
