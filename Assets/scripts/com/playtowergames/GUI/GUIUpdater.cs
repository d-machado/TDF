using UnityEngine;
using System.Linq;
using System.Collections;

public class GUIUpdater : MonoBehaviour {

	public TowerConstructionUI TowerCreationPanel;
    public UILabel LivesText;
    public UISprite LifeBarPrefab;

	private int mLives = 0;
	
	// Use this for initialization
	void Start () {
		TowerCreationPanel.hide();
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
		TowerCreationPanel.show ();
        var buttonArray = TowerCreationPanel.transform.Cast<Transform>().Where(c => c.gameObject.tag == "TowerButtons").Select(c => c.gameObject).ToArray();

        for (int i = 0; i < buttonArray.Length; i++)
        {
            GameObject aButton = buttonArray[i];
            TowerCreationButton aTCB = aButton.GetComponent<TowerCreationButton>();
            aTCB.TowerFactory = aTowerFactory;
        }
	}

    public void destroyLifeBar(UISprite aLifeBar)
    {
        Destroy(aLifeBar.gameObject);
    }

    public void updateEnemyHealthBar(float aLifePercent, Enemy aEnemy)
    {
        //Debug.Log("--> LIFE: " + aLifePercent);
        if (aEnemy.LifeBar == null)
        {
            UISprite aLifeBar = Instantiate(LifeBarPrefab) as UISprite;
            aLifeBar.transform.parent = transform;
            aLifeBar.transform.localScale = new Vector3(208,13,1);
            aLifeBar.transform.position = aEnemy.transform.position;
            aEnemy.LifeBar = aLifeBar;
        }
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
		TowerCreationPanel.hide ();
        aTowerFactory.createTower(aTower);
    } 

}
