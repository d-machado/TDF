using UnityEngine;
using System.Collections;

public class TowerFactory : MonoBehaviour {

	public delegate void ShowCreationGUIHandler();
	public event ShowCreationGUIHandler OnShowCreationGUIEvent;

	public delegate void MouseOutGUIHandler();
	public event MouseOutGUIHandler OnMouseOutGUIHandler;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		OnShowCreationGUIEvent();
	}

	void OnMouseOut(){
		OnMouseOutGUIHandler();
	}
}
