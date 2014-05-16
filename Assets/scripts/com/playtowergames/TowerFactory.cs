using UnityEngine;
using System.Collections;

public class TowerFactory : MonoBehaviour {

	public delegate void ShowCreationGUIHandler(TowerFactory aTowerFactory);
	public event ShowCreationGUIHandler OnShowCreationGUIEvent;

    public GameObject DamageAreaPrefab;

    private Tower mCurrentTower = null;

    public void createTower(Tower aTower)
    {

        hideDamageArea();
        GameObject aNewTower = Instantiate(aTower.gameObject) as GameObject;
        aNewTower.transform.parent = transform;

        mCurrentTower = aNewTower.GetComponent<Tower>();
    }

    public void showDamageArea(Tower aTower)
    {
        GameObject aDamageArea = Instantiate(DamageAreaPrefab) as GameObject;
        aDamageArea.name = "DamageArea";
        aDamageArea.transform.parent = transform;
    }

    public void hideDamageArea()
    {
        Transform aDamageArea = transform.FindChild("DamageArea");
        Destroy(aDamageArea.gameObject);
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
