using UnityEngine;
using System.Collections;

public class TowerCreationButton : MonoBehaviour {

    public delegate void TowerCreationButtonClickHandler(Tower aTowerType);
    public event TowerCreationButtonClickHandler onTowerCreationClickEvent;

    public Tower TowerPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        onTowerCreationClickEvent(TowerPrefab);
    }
}
