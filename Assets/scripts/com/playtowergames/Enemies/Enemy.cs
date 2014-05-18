using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float Life = 100f;

	// Use this for initialization

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Hit(float aDamage)
    {
        Life -= aDamage;
        if (Life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
