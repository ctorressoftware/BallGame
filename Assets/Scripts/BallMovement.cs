using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 20f;
    Rigidbody rgb;

    // Start is called before the first frame update
    void Start()
    {   
        rgb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rgb.AddForce(Vector3.forward * speed * Time.deltaTime, ForceMode.Impulse);
    }
}
