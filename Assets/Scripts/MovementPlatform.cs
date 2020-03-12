using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlatform : MonoBehaviour {

	public float speed = 0.1f;
	public float plusDistance; 
	float distance;
	public bool isAtDistance = false;
	Vector3 position;
	public char axis;
	Vector3 distancia;

	// Use this for initialization
	void Start () {
		
		distancia = this.transform.position;
	}

	// Update is called once per frame
	void FixedUpdate () {

		switch (axis) {
		case 'x':
			if (this.transform.position.x >= distancia.x+10) {
				isAtDistance = !isAtDistance;
			}

			else if (this.transform.position.x < distancia.x-10) {
				isAtDistance = !isAtDistance;
			}

			if (isAtDistance) {
				position = new Vector3 (-speed, 0f, 0f);
			} else {
				position = new Vector3 (speed, 0f, 0f);
			}
			break;

		case 'y':
			if (this.transform.position.y >= distancia.y + 10) {
				isAtDistance = !isAtDistance;
			}

			else if (this.transform.position.y < distancia.y - 10) {
				isAtDistance = !isAtDistance;
			}

			if (isAtDistance) {
				position = new Vector3 (0f, -speed, 0f);
			} else {
				position = new Vector3 (0f, speed, 0f);
			}
			break;

		case 'z':
			if (this.transform.position.z >= distancia.z + 10) {
				isAtDistance = !isAtDistance;
			}

			else if (this.transform.position.z < distancia.z - 10) {
				isAtDistance = !isAtDistance;
			}

			if (isAtDistance) {
				position = new Vector3 (0f, 0f, -speed);
			} else {
				position = new Vector3 (0f, 0f, speed);
			}
			break;
		}

		MovePlatform ();
	}

	void MovePlatform()
	{
		this.transform.Translate (position * Time.deltaTime);
	}  

}
