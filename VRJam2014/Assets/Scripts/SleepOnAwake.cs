using UnityEngine;
using System.Collections;

public class SleepOnAwake : MonoBehaviour {

	void Awake()
	{
		rigidbody.Sleep ();
	}
}
