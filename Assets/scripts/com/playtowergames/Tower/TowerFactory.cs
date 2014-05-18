using UnityEngine;
using System.Collections;

public class TowerFactory : MonoBehaviour {

	public delegate void ShowCreationGUIHandler(TowerFactory aTowerFactory);
	public event ShowCreationGUIHandler OnShowCreationGUIEvent;

    public GameObject DamageAreaPrefab;
    public Tower StartWithTower;

    private Tower mCurrentTower = null;

    public void createTower(Tower aTower)
    {

        hideDamageArea();
        GameObject aNewTower = Instantiate(aTower.gameObject) as GameObject;
        aNewTower.transform.parent = transform;
        aNewTower.transform.localPosition = Vector3.zero;

        mCurrentTower = aNewTower.GetComponent<Tower>();
    }

    public void showDamageArea(Tower aTower)
    {
        GameObject aDamageArea = Instantiate(DamageAreaPrefab) as GameObject;
        aDamageArea.name = "DamageArea";
        aDamageArea.transform.parent = transform;
        aDamageArea.transform.localPosition = new Vector3(0f, .5f);
    }

    public void hideDamageArea()
    {
        Transform aDamageArea = transform.FindChild("DamageArea");
        if (aDamageArea != null) { Destroy(aDamageArea.gameObject); }
    }

	// Use this for initialization
	void Start () {
        if (StartWithTower)
        {
            createTower(StartWithTower);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
        Debug.Log("MOUSE DOWN");
        if (mCurrentTower == null)
        {
            Debug.Log("TOWER CLICK");
            if (OnShowCreationGUIEvent != null) {
                Debug.Log("Event Exist");
                OnShowCreationGUIEvent(this); 
            }
        }
	}

}
