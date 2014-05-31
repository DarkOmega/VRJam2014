using UnityEngine;
using System.Collections;

public class SpecialBlock : MonoBehaviour {
	
	float radius = 5.0F;
	float power = 100.0F;

	public string triggerTag = "Ground";
	public bool explosionForce = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == triggerTag) {

			if (explosionForce)
			{
				Vector3 explosionPos = transform.position;
				Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);
				foreach (Collider hit in colliders) {
					if (hit && hit.rigidbody)
					{
						hit.rigidbody.AddExplosionForce (power, explosionPos, radius, 30.0F);
					}
				}
			}
			Destroy (gameObject);
		}
	}
}
