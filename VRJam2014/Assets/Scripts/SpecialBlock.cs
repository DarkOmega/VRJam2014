using UnityEngine;
using System.Collections;

public class SpecialBlock : MonoBehaviour {
	
	float radius = 5.0F;
	float power = 100.0F;

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
				foreach (Collider hit in colliders) {
					if (hit && hit.rigidbody)
					{
						hit.rigidbody.AddExplosionForce (power, explosionPos, radius, 30.0F);
					}
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
