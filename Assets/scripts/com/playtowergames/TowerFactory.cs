using UnityEngine;
using System.Collections;

public class TowerFactory : MonoBehaviour {

	public delegate void ShowCreationGUIHandler(TowerFactory aTowerFactory);
	public event ShowCreationGUIHandler OnShowCreationGUIEvent;

    private Tower mCurrentTower = null;

    public void createTower(Tower aTower)
    {
        Debug.Log(aTower);
        GameObject aNewTower = Instantiate(aTower.gameObject) as GameObject;
        aNewTower.transform.parent = transform;

        mCurrentTower = aNewTower.GetComponent<Tower>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
        if (mCurrentTower == null)
        {
            OnShowCreationGUIEvent(this);
        }
	}

}
