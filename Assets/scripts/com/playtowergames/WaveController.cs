using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveController : MonoBehaviour {

    public Wave[] Waves;

    private LevelController mLevelController;

	// Use this for initialization
	void Start () {
        mLevelController = GetComponent<LevelController>();

        showFirstWave();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void showFirstWave()
    {
        if(Waves.Length > 0){
            Wave aWave = Waves[0];
            startWave(aWave);
        }
    }

    private void startWave(Wave aWave)
    {
        
        Dictionary<string, iTweenPath> aPaths = iTweenPath.paths;

        for (int i = 0; i < aWave.AmountOfEnemies; i++)
        {
            GameObject aEnemy = mLevelController.GetNewInstanceOfEnemy(aWave.TypeOfEnemies);
            EnemyMovement aEnemyMovement = aEnemy.GetComponent<EnemyMovement>();

            System.Random aRandom = new System.Random();
            int aPathIndex = aRandom.Next(aPaths.Count);
            string[] keys = new string[aPaths.Count];
            aPaths.Keys.CopyTo(keys, 0);

            float aStartPercentage = (float)(aRandom.NextDouble() * 10d);

            aEnemyMovement.putOnPath(keys[aPathIndex], aStartPercentage);
        }
    }
}
