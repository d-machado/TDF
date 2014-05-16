using UnityEngine;
using System.Collections;

public class TowerCreationButton : MonoBehaviour {

    public delegate void TowerCreationButtonClickHandler(Tower aTowerType, TowerFactory aTowerFactory);
    public event TowerCreationButtonClickHandler onTowerCreationClickEvent;

    public delegate void TowerCreationButtonOverHandler(Tower aTowerType, TowerFactory aTowerFactory);
    public event TowerCreationButtonOverHandler onTowerCreationOverEvent;

    public delegate void TowerCreationButtonOutHandler(TowerFactory aTowerFactory);
    public event TowerCreationButtonOutHandler onTowerCreationOutEvent;

    public Tower TowerPrefab;

    private TowerFactory mTowerFactory;

    public TowerFactory TowerFactory
    {
        set
        {
            Debug.Log(value);
            mTowerFactory = value;
            Debug.Log(mTowerFactory);
        }
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        Debug.Log(mTowerFactory);
        onTowerCreationClickEvent(TowerPrefab, mTowerFactory);
    }

    void OnMouseEnter()
    {
        onTowerCreationOverEvent(TowerPrefab, mTowerFactory);
    }

    void OnMouseExit()
    {
        onTowerCreationOutEvent(mTowerFactory);
    }
}
