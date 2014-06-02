using UnityEngine;
using System.Collections;

public class TowerConstructionUI : MonoBehaviour {

	public UIButton[] TowerButtons;

	private GameController _controller;
	private UIPanel _panel;

	void Awake(){
		_controller = GameObject.Find("Controller").GetComponent<GameController>();
		_panel = GetComponent<UIPanel>();
	}
	

	public void hide(){
		_panel.enabled = false;
	}
	public void show(){
		int aCoins = _controller.getUser().Coins;
		
		for(int i = 0; i < TowerButtons.Length; i++){
			TowerCreationButton button = TowerButtons[i].GetComponent<TowerCreationButton>();
			if(button.TowerPrefab.Cost > aCoins){
				TowerButtons[i].enabled = false;
			}else{
				TowerButtons[i].enabled = true;
			}
		}
		
		_panel.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {

	}
	
}
