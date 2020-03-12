using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsGenerator : MonoBehaviour {

    public GameObject ball;

	// Use this for initialization
	void Start () {
        InvokeRepeating("InstantiateBall", 0.0f, 2f);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void InstantiateBall() {
        Instantiate(ball);
    }



}
