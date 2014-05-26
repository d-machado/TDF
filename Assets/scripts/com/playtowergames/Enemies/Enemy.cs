using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float Life = 100f;

    private GUIUpdater _GUI;

    private float _initialLife;
	// Use this for initialization

	void Start () {
        _initialLife = Life;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetUIController(GUIUpdater aGUI){
        _GUI = aGUI;
    }

    public void Hit(float aDamage)
    {
        Life -= aDamage;
        if (Life <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            float aPercent = (Life * 100) / _initialLife;
            _GUI.updateEnemyHealthBar(aPercent, transform);
        }
    }
}
