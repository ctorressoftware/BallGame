using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoserPlatformController : MonoBehaviour {

	public GameObject game;

	public void OnTriggerEnter (Collider other)
	{
        if (other.gameObject.tag == "Ball")
        {
            game.SendMessage("SetGameState", GameState.GameOver);
        }

        else if (other.gameObject.tag == "BlueBall") {
            Destroy(other.gameObject);
        }

	}
}
