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
	private TowerConstructionUI _towerCreationGUI;

	public TowerConstructionUI TowerConstruction{
		set { _towerCreationGUI = value; }
	}

    public TowerFactory TowerFactory
    {
        set
        {
            mTowerFactory = value;
        }
    }

	public void OnMouseDownMessage()
    {
       onTowerCreationClickEvent(TowerPrefab, mTowerFactory);
    }

    public void OnMouseEnterMessage()
    {
        onTowerCreationOverEvent(TowerPrefab, mTowerFactory);
    }

    public void OnMouseExitMessage()
    {
        onTowerCreationOutEvent(mTowerFactory);
    }
}
