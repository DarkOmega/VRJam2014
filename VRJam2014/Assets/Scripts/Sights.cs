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
	void Update () {
		RaycastHit hit;
		bool didHit = Physics.Raycast (SteamVR_Camera.Instance.offset.position, SteamVR_Camera.Instance.offset.forward, out hit);
		if (didHit) {
						spawned.transform.position = hit.point;
			spawned.SetActive(true);
				} else {
			spawned.SetActive(false);
				}
	}
}
