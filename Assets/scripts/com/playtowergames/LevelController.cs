using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

    public Enemy[] Enemies;
    public int Lives = 1;
	private GameObject aFlagInstance;
    private int mInvaders = 0;
    
    public GameObject GetNewInstanceOfEnemy(EnemyTypesEnum aType)
    {
        Enemy aEnemy = null;
        for (int i = 0; i < Enemies.Length; i++)
        {
            if (Enemies[i].Type == aType)
            {
                aEnemy = Enemies[i];
                break;
            }
        }

        GameObject aEnemyInstance = Instantiate(aEnemy.EnemyPrefab) as GameObject;
        EnemyMovement aEnemyMovement = aEnemyInstance.GetComponent<EnemyMovement>();
        aEnemyMovement.OnEnemyInvasion += new EnemyMovement.EnemyInvasionHandler(onEnemyInvasion);
        aEnemyMovement.Speed = Random.Range(aEnemy.MinSpeed, aEnemy.MaxSpeed);
        return aEnemyInstance;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void onEnemyInvasion()
    {
        mInvaders++;
        Debug.Log(mInvaders.ToString() + " Invaders");
    }

}
