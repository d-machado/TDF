using UnityEngine;
using System.Collections;

public class TowerFactory : MonoBehaviour {

	public delegate void ShowCreationGUIHandler();
	public event ShowCreationGUIHandler OnShowCreationGUIEvent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		OnShowCreationGUIEvent();
	}

}
