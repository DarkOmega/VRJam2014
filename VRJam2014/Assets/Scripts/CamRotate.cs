using UnityEngine;
using System.Collections;

public class CamRotate : MonoBehaviour {

	float currentAngle = 0;
	float targetAngle = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Joystick1Button5))
		{
			targetAngle -= 90.0f;
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Joystick1Button4))
		{
			targetAngle += 90.0f;
		}
		if (currentAngle != targetAngle)
		{
			float difference = targetAngle-currentAngle;
			float maxDelta = 300.0f*Time.deltaTime;
			float delta;
			if (Mathf.Abs(difference)>maxDelta)
			{
				if (difference < 0)
					delta = -1.0f*maxDelta;
				else
					delta = 1.0f*maxDelta;
			}
			else
			{
				delta = difference;
			}
			currentAngle += delta;
			transform.rotation = Quaternion.Euler(0.0f, currentAngle, 0.0f);
		}
	}
}
