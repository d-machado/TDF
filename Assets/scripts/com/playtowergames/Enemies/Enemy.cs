using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float Life = 100f;

    private GUIUpdater _GUI;

    private float _initialLife;
    private UISprite _lifeBar;
    private Vector3 _lifeBarPosition;

    public UISprite LifeBar
    {
        get { return _lifeBar; }
        set { _lifeBar = value; }
    }
	// Use this for initialization

	void Start () {
        _initialLife = Life;
        _lifeBarPosition = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        if (_lifeBar)
        {
            _lifeBarPosition.x = transform.position.x;
            _lifeBarPosition.y = transform.position.y + .3f;
            _lifeBarPosition.z = transform.position.z;
            _lifeBar.transform.position = _lifeBarPosition;
        }
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
            if (LifeBar)
            {
                _GUI.destroyLifeBar(LifeBar);
                LifeBar = null;
            }
        }
        else
        {
            float aPercent = (Life * 100) / _initialLife;
            _GUI.updateEnemyHealthBar(aPercent, this);
            if (LifeBar)
            {
                Debug.Log("Percent: " + (aPercent / 100));
                LifeBar.fillAmount = (aPercent / 100);
            }
        }
    }
}
