using UnityEngine;
using System.Linq;
using System.Collections;

public class GUIUpdater : MonoBehaviour {

	public UIPanel TowerCreationPanel;
    public UILabel LivesText;
    public UISprite LifeBarPrefab;

	private int mLives = 0;
	
	// Use this for initialization
	void Start () {
        TowerCreationPanel.enabled = false;
        var buttonArray = TowerCreationPanel.transform.Cast<Transform>().Where(c => c.gameObject.tag == "TowerButtons").Select(c => c.gameObject).ToArray();

        for (int i = 0; i < buttonArray.Length; i++)
        {
            GameObject aButton = buttonArray[i];
            TowerCreationButton aTCB = aButton.GetComponent<TowerCreationButton>();
            aTCB.onTowerCreationClickEvent += new TowerCreationButton.TowerCreationButtonClickHandler(onTowerCreationButtonClick);
            aTCB.onTowerCreationOverEvent += new TowerCreationButton.TowerCreationButtonOverHandler(onTowerCreationButtonOver);
            aTCB.onTowerCreationOutEvent += new TowerCreationButton.TowerCreationButtonOutHandler(onTowerCreationButtonOut);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setInitialLives(int aLives){
		mLives = aLives;
        LivesText.text = "LIVES " + aLives;
	}

	public void updateLives(int aLives){
		mLives = aLives;
        LivesText.text = "LIVES " + aLives;
	}

	public void showConstructionGUI(TowerFactory aTowerFactory){
        TowerCreationPanel.enabled = true;
        var buttonArray = TowerCreationPanel.transform.Cast<Transform>().Where(c => c.gameObject.tag == "TowerButtons").Select(c => c.gameObject).ToArray();

        for (int i = 0; i < buttonArray.Length; i++)
        {
            GameObject aButton = buttonArray[i];
            TowerCreationButton aTCB = aButton.GetComponent<TowerCreationButton>();
            aTCB.TowerFactory = aTowerFactory;
        }
	}

    public void updateEnemyHealthBar(float aLifePercent, Transform aEnemy)
    {
        //Debug.Log("--> LIFE: " + aLifePercent);
        UISprite aLifeBar = Instantiate(LifeBarPrefab) as UISprite;
        
        
    }

    void onTowerCreationButtonOut(TowerFactory aTowerFactory)
    {
        aTowerFactory.hideDamageArea();
    }

    void onTowerCreationButtonOver(Tower aTower, TowerFactory aTowerFactory)
    {
        aTowerFactory.showDamageArea(aTower);
    }

    void onTowerCreationButtonClick(Tower aTower, TowerFactory aTowerFactory)
    {
        TowerCreationPanel.enabled = false;
        aTowerFactory.createTower(aTower);
    } 

}
