using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour {

    public float RealoadTime = 2f;
    public GameObject Amunition;
	public int Cost = 10;

	// Use this for initialization
    private List<Transform> _targetsInRange;
    private Transform _firePoint;
    private float _nextFireTime = 0f;

	void Start () {
        _targetsInRange = new List<Transform>();
        _firePoint = transform.Find("tower_fire_point");
	}
	
	// Update is called once per frame
	void Update () {
        if (_targetsInRange.Count > 0 && Time.time >= _nextFireTime)
        {
            Transform aTarget = _targetsInRange[0];

            if (aTarget != null)
            {
                //Create bullet
                GameObject aBullet = Instantiate(Amunition) as GameObject;
                aBullet.transform.parent = _firePoint;
                aBullet.transform.localPosition = Vector3.zero;
                Bullet aBulletScript = aBullet.GetComponent<Bullet>();
                aBulletScript.SetTarget(aTarget);
                _nextFireTime = Time.time + RealoadTime;
            }
            else
            {
                _targetsInRange.RemoveAt(0);
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemies")
        {
            _targetsInRange.Add(other.transform);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemies")
        {
            _targetsInRange.Remove(other.transform);
        }
    }
}
