using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	bool hit = false;

	// Use this for initialization
	void Start () {
		GameMgr.Instance.RegisterBlock (this);


		float floorY = GameMgr.Instance.podiumRoot.transform.position.y;
		float minY = transform.position.y;

		Collider[] colliders = GetComponentsInChildren<Collider> ();
		foreach (Collider c in colliders) 
		{
			if (c.bounds.min.y < minY)
				minY = c.bounds.min.y;
		}

		if (minY < floorY + .01f) {
			SetHit();
				}
	}
	
	// Update is called once per frame
	void OnCollisionEnter(Collision collision) 
	{
		if (collision.gameObject.tag == "Ground") 
		{
			SetHit();
		}
	}

	public void SetHit()
	{
		if (!hit) {
						GameMgr.Instance.BlockHitGround (this);
						Destroy (this);
			hit = true;
				}
	}
}
