using UnityEngine;
using System.Collections;

public class TowerCreationButton : MonoBehaviour {

    public delegate void TowerCreationButtonClickHandler(Tower aTowerType, TowerFactory aTowerFactory);
    public event TowerCreationButtonClickHandler onTowerCreationClickEvent;

    public Tower TowerPrefab;

    private TowerFactory mTowerFactory;

    public TowerFactory TowerFactory
    {
        set
        {
            mTowerFactory = value;
        }
    }

	// Use this for initialization
	void Start () {
        mTowerFactory = null;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        onTowerCreationClickEvent(TowerPrefab, mTowerFactory);
    }
}
