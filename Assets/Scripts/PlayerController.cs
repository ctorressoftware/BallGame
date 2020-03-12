using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speedBall = 600f;
	public float speedBallRotation = 30f;
    public bool isGrounded = false;
    Rigidbody rgb;

	// Use this for initialization
	void Start () {
		rgb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void Move(){

		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			rgb.AddForce (Vector3.forward * speedBall * Time.deltaTime, ForceMode.Force);
			this.transform.Rotate (new Vector3(speedBallRotation, 0f, 0f) * Time.deltaTime, Space.Self);
		} 
		if (Input.GetKey (KeyCode.RightArrow)) 
		{	
			rgb.AddForce (Vector3.right * speedBall * Time.deltaTime, ForceMode.Force);
			this.transform.Rotate (new Vector3(0f, 0f, speedBallRotation) * Time.deltaTime, Space.Self);
		}
		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			rgb.AddForce (Vector3.back * speedBall * Time.deltaTime, ForceMode.Force);
			this.transform.Rotate (new Vector3(-speedBallRotation, 0f, 0f) * Time.deltaTime, Space.Self);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			rgb.AddForce (Vector3.left * speedBall * Time.deltaTime, ForceMode.Force);
			this.transform.Rotate (new Vector3(0f, 0f, -speedBallRotation) * Time.deltaTime, Space.Self);
		}
        if (Input.GetKeyDown(KeyCode.Space) && GameController.actualScene==9 && isGrounded) {
            this.Jump();
        }
	}

	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "MovingPlatform")
		{
			transform.parent = other.gameObject.transform;

        } else if (other.gameObject.tag == "NormalPlatform")
        {
            isGrounded = true;
        }
    }

	void OnTriggerExit(Collider other)
	{
		transform.parent = null;
        isGrounded = false;
	}

    void Jump() {

        rgb.AddForce(Vector3.up * 1000f, ForceMode.Force);
    }
}
