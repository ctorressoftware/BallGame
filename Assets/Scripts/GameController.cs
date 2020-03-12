using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState {Idle, Playing, GameOver, LevelCompleted}

public class GameController : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject loserMenu;
	public GameObject winnerMenu;
	public GameObject ball;
	public GameObject camera;
	public GameObject loserPlatform;
	public GameState state = GameState.Idle;
	public static int actualScene;
	bool isCubeTouched = false;

	// Use this for initialization
	void Start () {
		actualScene = SceneManager.GetActiveScene ().buildIndex;
	}
	
	// Update is called once per frame
	void Update () {
		if (state == GameState.Idle && Input.GetKey (KeyCode.Space)) {
			state = GameState.Playing;
			ball.GetComponent<Rigidbody> ().useGravity = false;
		}
		else if (state == GameState.Playing)  
		{
			Physics.gravity = new Vector3(0f, -20f, 0f);
			mainMenu.SetActive (false);
			ball.GetComponent<Rigidbody> ().useGravity = true;
			ball.SendMessage ("Move");

			//PARA CONTROLAR VISTA DE LAS ESCENAS /////////////////////////////////////////
			if (actualScene == 1) 
			{
				if (camera.transform.position.y > 26) 
				{
					camera.transform.Translate (new Vector3 (0f, -2f, 0f) * Time.deltaTime);
				}

				if (camera.transform.position.z > -51) 
				{
					camera.transform.Translate (new Vector3 (0f, 0f, -2f) * Time.deltaTime);
				}

			} 
			else if (actualScene == 3 && isCubeTouched) // x= -15, z = -90
			{
				camera.transform.position = new Vector3 (camera.transform.position.x, 29, camera.transform.position.z);

				if (camera.transform.position.x > -15) 
				{
					camera.transform.Translate (new Vector3 (-10f, 0f, 0f) * Time.deltaTime);
				}

				if (camera.transform.position.z > -90 && camera.transform.position.x <= -15) 
				{
					camera.transform.Translate (new Vector3 (0f, 0f, -15f) * Time.deltaTime);
				}
			}
			else if (actualScene == 5)
			{
				camera.transform.position = new Vector3 (ball.transform.position.x, ball.transform.position.y + 15f, camera.transform.position.z);
			}
			else if (actualScene == 6)
			{
				camera.transform.position = new Vector3 (ball.transform.position.x, ball.transform.position.y + 20f, camera.transform.position.z);
			}
            else if (actualScene == 7)
            {
                camera.transform.position = new Vector3(ball.transform.position.x, 20, ball.transform.position.z);
            }
            else if (actualScene == 8)
            {
                camera.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y+10f, ball.transform.position.z-30);
            }
            else if (actualScene == 9)
            {
                camera.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y + 15f, camera.transform.position.z);
            }
        }
		else if (state == GameState.GameOver)  
		{
			loserMenu.SetActive (true);

			if (Input.GetKey (KeyCode.Space)) {
				SetScene (actualScene);
			}
		}
		else if (state == GameState.LevelCompleted)  
		{
			loserPlatform.SetActive(false);
			winnerMenu.SetActive (true);

			if (Input.GetKey (KeyCode.Space)) {
				SetScene (++actualScene);
			}
		}
		if (Input.GetKey ("escape")) 
		{
			Application.Quit ();
		}

		actualScene = SceneManager.GetActiveScene ().buildIndex;
	}

	public void SetGameState(GameState state)
	{
		this.state = state;
	}

	void SetScene(int level)
	{
		SceneManager.LoadScene (level);
	}

	void SetCubeTouched()
	{
		this.isCubeTouched = true;
	}

    public int GetActualScene()
    {
        return actualScene;
    }
}
