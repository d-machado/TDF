using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization

    private GameController _gameController;

	void Start () {
        _gameController = GameObject.Find("Controller").GetComponent<GameController>();
        _gameController.showUI(GameUIEnum.MAIN_MENU);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
