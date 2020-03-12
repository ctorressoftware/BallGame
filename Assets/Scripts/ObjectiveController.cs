using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour {

	public GameObject game;

	public void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Ball") 
		{
			game.SendMessage ("SetGameState", GameState.LevelCompleted);
		}
	}
}
