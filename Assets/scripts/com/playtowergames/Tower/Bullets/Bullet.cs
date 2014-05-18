using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization

    public Transform Target;
    public float Speed = 5f;
    public float Damage = 20f;
    public float MinDistanceToExplode = .2f;

    private Enemy _enemyScript;

    void Start () {

    }

    public void SetTarget(Transform aTarget)
    {
        if (aTarget.tag == "Enemies")
        {
            _enemyScript = aTarget.GetComponent<Enemy>();
            Target = aTarget;
        }
    }

	// Update is called once per frame
	void Update () {
        if (Target)
        {
            float step = Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Target.position, step);
            if (Vector3.Distance(transform.position, Target.position) <= MinDistanceToExplode)
            {
                if (_enemyScript)
                {
                    _enemyScript.Hit(Damage);
                }
                Destroy(gameObject);
            }
        }
	}
}
