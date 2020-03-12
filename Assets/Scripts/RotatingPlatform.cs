using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour {

	public float speedRotation = 30f;
	Vector3 position;
	public char axis;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RotatePlatform (axis);
	}

	void RotatePlatform(char axis)
	{
		Vector3 position = new Vector3(speedRotation, 0f, 0f);

		switch (axis) {
		case 'x':
			position = new Vector3 (speedRotation, 0f, 0f);
			this.transform.Rotate (position * Time.deltaTime, Space.Self);
			break;

		case 'y':
			position = new Vector3 (0f, speedRotation, 0f);
			this.transform.Rotate (position * Time.deltaTime, Space.Self);
			break;

		case 'z':
			position = new Vector3 (0f, 0f, speedRotation);
			this.transform.Rotate (position * Time.deltaTime, Space.Self);
			break;
		}
	}
}
