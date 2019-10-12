using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
	enum 		GameState{ Ready, Play, GameOver}

	GameState 	currentGameState;

	int 		currentScore;

	public AzarashiController currentAzarashiController;
	public GameObject		  blocks;
	public Text				  scoreLabel;
	public Text				  stateLabel;

	void Start(){
		Ready();
	}

	void LateUpdate(){
		switch(currentGameState){
			case GameState.Ready:
				if(Input.GetButtonDown("Fire1")) GameStart();
				break;
			case GameState.Play:
				if(currentAzarashiController.IsDead()) GameOver();
				break;
			case GameState.GameOver:
				if(Input.GetButtonDown("Fire1")) Reload();
				break;
			default:
				break;
		}
	}

	void Ready(){
		currentGameState = GameState.Ready;

		currentAzarashiController.SetSteerActive(false);
		blocks.SetActive(false);

		scoreLabel.text = "Score : " + 0;

		stateLabel.gameObject.SetActive(true);
		stateLabel.text = "Ready";
	}

	void GameStart(){
		currentGameState = GameState.Play;

		currentAzarashiController.SetSteerActive(true);
		blocks.SetActive(true);

		currentAzarashiController.Flap();

		stateLabel.gameObject.SetActive(true);
		stateLabel.text = "";
	}

	void GameOver(){
		currentGameState = GameState.GameOver;

		ScrollController[] scrollObjects = GameObject.FindObjectsOfType<ScrollController>();
		foreach (ScrollController so in scrollObjects) so.enabled = false;
		
		stateLabel.gameObject.SetActive(true);
		stateLabel.text = "GameOver";
	}

	void Reload(){
		Application.LoadLevel(Application.loadedLevel);
	}

	public void IncreaseScore(){
		currentScore++;

		scoreLabel.text = "Score : " + currentScore;
	}
}