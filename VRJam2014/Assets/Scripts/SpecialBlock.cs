using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpecialBlock : MonoBehaviour {
	
	float radius = .1F;
	float power = 800.0F;

	public enum Trigger
	{
		kGround,
		kProjectile
	}
	public Trigger trigger;
	string triggerTag;


	public enum Behavior
	{
		kExplode,
		kLose,
		kPoints
	}
	public Behavior behavior;

	// Use this for initialization
	void Start () {
		GameMgr.Instance.RegisterSpecialBlock (this);
		if (trigger == Trigger.kGround)
						triggerTag = "Ground";
				else
						triggerTag = "Bullet";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == triggerTag) {

			if (behavior == Behavior.kExplode)
			{
				Vector3 explosionPos = transform.position;
				Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);
				HashSet<Rigidbody> bodies = new HashSet<Rigidbody>();
				foreach (Collider hit in colliders) {
					if (hit && hit.rigidbody)
					{
						bodies.Add (hit.rigidbody);
					}
					if (hit && hit.transform.parent && hit.transform.parent.rigidbody)
					{
						bodies.Add (hit.transform.parent.rigidbody);
					}
				}
				foreach (Rigidbody body in bodies)
				{
					body.AddExplosionForce (power, explosionPos, radius, 0.0F);
				}
				Destroy (gameObject);
			}
			else if (behavior == Behavior.kLose)
			{
				GameMgr.Instance.LoseBlockHit(this);
				Destroy (gameObject);
			}
			else if (behavior == Behavior.kPoints)
			{
				GameMgr.Instance.PointBlockHit(this);
				Destroy (gameObject);
			}
		}
	}
}
