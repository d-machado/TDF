using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveController : MonoBehaviour {

    public Wave[] Waves;

    private LevelController mLevelController;
    private System.Random mRandom = new System.Random();
    private int mCurrentWaveIndex = 0;

    void Awake()
    {
        mLevelController = GetComponent<LevelController>();
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void showFirstWave()
    {

        if(Waves.Length > 0){
            startWave();
        }

    }

    private void showNextWave()
    {
        if (mCurrentWaveIndex >= Waves.Length)
        {
            Debug.Log("Survived to invasion");
        }
        else
        {
            Wave aNextWave = Waves[mCurrentWaveIndex];
            Invoke("startWave", aNextWave.StartTime);
        }
    }

    private void startWave()
    {

        Wave aWave = Waves[mCurrentWaveIndex];
        Dictionary<string, iTweenPath> aPaths = iTweenPath.paths;

        for (int i = 0; i < aWave.AmountOfEnemies; i++)
        {
            GameObject aEnemy = mLevelController.GetNewInstanceOfEnemy(aWave.TypeOfEnemies);
            EnemyMovement aEnemyMovement = aEnemy.GetComponent<EnemyMovement>();
            

            
            int aPathIndex = mRandom.Next(aPaths.Count);
            string[] keys = new string[aPaths.Count];
            aPaths.Keys.CopyTo(keys, 0);

            float aStartPercentage = (float)(mRandom.Next(10) / 100f);
            aEnemyMovement.putOnPath(keys[aPathIndex], aStartPercentage);
        }
        mCurrentWaveIndex++;
        showNextWave();
    }
}
