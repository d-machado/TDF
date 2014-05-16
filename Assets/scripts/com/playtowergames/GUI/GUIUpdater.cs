using UnityEngine;
using System.Linq;
using System.Collections;

public class GUIUpdater : MonoBehaviour {

	public GameObject TowerCreationGUIPrefab;

	private Rect mLivesLabelPosition = new Rect(7, 5, 80, 60);
	private int mLives = 0;
	private GameObject mTowerCreationGUI = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setInitialLives(int aLives){
		mLives = aLives;
	}

	public void updateLives(int aLives){
		mLives = aLives;
	}

	public void showConstructionGUI(TowerFactory aTowerFactory){
		if(!mTowerCreationGUI){
			mTowerCreationGUI = Instantiate(TowerCreationGUIPrefab) as GameObject;
			mTowerCreationGUI.transform.parent = transform;

            var buttonArray = mTowerCreationGUI.transform.Cast<Transform>().Where(c => c.gameObject.tag == "TowerButtons").Select(c => c.gameObject).ToArray();

            for (int i = 0; i < buttonArray.Length; i++)
            {
                GameObject aButton = buttonArray[i];
                TowerCreationButton aTCB = aButton.GetComponent<TowerCreationButton>();
                aTCB.TowerFactory = aTowerFactory;
                aTCB.onTowerCreationClickEvent += new TowerCreationButton.TowerCreationButtonClickHandler(onTowerCreationButtonClick);
                aTCB.onTowerCreationOverEvent += new TowerCreationButton.TowerCreationButtonOverHandler(onTowerCreationButtonOver);
                aTCB.onTowerCreationOutEvent += new TowerCreationButton.TowerCreationButtonOutHandler(onTowerCreationButtonOut);
            }
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
        if (mTowerCreationGUI)
        {
            Destroy(mTowerCreationGUI);
            mTowerCreationGUI = null;
        }
        Debug.Log(aTowerFactory);
        aTowerFactory.createTower(aTower);
    } 

	void OnGUI(){
		GUI.Label(mLivesLabelPosition, "LIVES: " + mLives.ToString());
	}
}
