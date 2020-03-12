using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //780
    {
        if (transform.position.y < 820)
        {
            this.transform.Translate(Vector3.up * 30f * Time.deltaTime);
        }

        if (Input.GetKey("escape"))
        {
            Debug.Log("Funciona");
            Application.Quit();
        }


        //Debug.Log(transform.position);
    }


}
