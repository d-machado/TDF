using UnityEngine;
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

	public void onTowerFactoryMouseOut(){
		if(mTowerCreationGUI){
			Destroy(mTowerCreationGUI);
		}
	}

	public void showConstructionGUI(){
		if(!mTowerCreationGUI){
			mTowerCreationGUI = Instantiate(TowerCreationGUIPrefab) as GameObject;
			mTowerCreationGUI.transform.parent = transform;
		}
	}

	void OnGUI(){
		GUI.Label(mLivesLabelPosition, "LIVES: " + mLives.ToString());
	}
}
