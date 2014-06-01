using UnityEngine;
using System.Collections;

public class Sights : MonoBehaviour {

	public GameObject sightPrefab;

	GameObject spawned;

	// Use this for initialization
	void Start () {
		spawned = Instantiate (sightPrefab) as GameObject;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		RaycastHit hit;
		Transform t;
		if (SteamVR_Camera.Instance.offset != null)
						t = SteamVR_Camera.Instance.offset;
				else
						t = SteamVR_Camera.Instance.transform;
		bool didHit = Physics.Raycast (t.position, t.forward, out hit);
		if (didHit) {
						spawned.transform.position = hit.point;
			spawned.SetActive(true);
				} else {
			spawned.SetActive(false);
				}
	}
}
