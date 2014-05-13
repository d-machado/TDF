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

	public void showConstructionGUI(){
		if(!mTowerCreationGUI){
			mTowerCreationGUI = Instantiate(TowerCreationGUIPrefab) as GameObject;
			mTowerCreationGUI.transform.parent = transform;

            var buttonArray = mTowerCreationGUI.transform.Cast<Transform>().Where(c => c.gameObject.tag == "TowerButtons").Select(c => c.gameObject).ToArray();

            for (int i = 0; i < buttonArray.Length; i++)
            {
                GameObject aButton = buttonArray[i];
                //Add event ToweButton component
            }
		}
	}

	void OnGUI(){
		GUI.Label(mLivesLabelPosition, "LIVES: " + mLives.ToString());
	}
}
