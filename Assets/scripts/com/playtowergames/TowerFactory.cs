using UnityEngine;
using System.Collections;

public class TowerFactory : MonoBehaviour {

	public delegate void ShowCreationGUIHandler(TowerFactory aTowerFactory);
	public event ShowCreationGUIHandler OnShowCreationGUIEvent;


    public void createTower(Tower aTower)
    {
        GameObject aNewTower = Instantiate(aTower.gameObject) as GameObject;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		OnShowCreationGUIEvent(this);
	}

}
