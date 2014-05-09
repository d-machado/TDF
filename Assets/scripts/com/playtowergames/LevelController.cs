using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

    public Enemy[] Enemies;
	public GameObject flag;
    public string FlagPath;
	private GameObject aFlagInstance;


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

        return Instantiate(aEnemy.EnemyPrefab) as GameObject;
    }

	// Use this for initialization
	void Start () {
		aFlagInstance = Instantiate (flag) as GameObject;
        iTween.PutOnPath (aFlagInstance, iTweenPath.GetPath (FlagPath), .95f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}



}
