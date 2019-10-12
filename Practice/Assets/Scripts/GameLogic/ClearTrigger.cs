using UnityEngine;
using System.Collections;

public class ClearTrigger : MonoBehaviour
{
	GameObject currentGameController;

	void Start(){
		currentGameController = GameObject.FindWithTag("GameController");
	}

	void OnTriggerExit2D(Collider2D other){
		currentGameController.SendMessage("IncreaseScore");
	}
}