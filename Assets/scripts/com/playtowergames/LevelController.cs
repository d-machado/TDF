using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	public TowerFactory[] Towers;
	public Enemy[] Enemies;
    public int Lives = 1;
	public GameObject GuiContainer;
	private GameObject aFlagInstance;
    private int mInvaders = 0;
	private GUIUpdater mGuiUpdater;
    
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
        aEnemyMovement.OnEnemyInvasionEvent += new EnemyMovement.EnemyInvasionHandler(onEnemyInvasion);
        aEnemyMovement.Speed = Random.Range(aEnemy.MinSpeed, aEnemy.MaxSpeed);
        return aEnemyInstance;
    }

	// Use this for initialization
	void Start () {
		mGuiUpdater = GuiContainer.GetComponent<GUIUpdater>();
		mGuiUpdater.setInitialLives(Lives);

		for(int i = 0; i < Towers.Length; i++){
			Towers[i].OnShowCreationGUIEvent += new TowerFactory.ShowCreationGUIHandler(onShowCreationGUI);
			Towers[i].OnMouseOutGUIHandler += new TowerFactory.MouseOutGUIHandler(mGuiUpdater.onTowerFactoryMouseOut);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void onShowCreationGUI(){
		mGuiUpdater.showConstructionGUI();
	}

    private void onEnemyInvasion()
    {
        Lives--;
		mGuiUpdater.updateLives(Lives);

		if(Lives <= 0){
			Debug.Log("User Lose of invasion");
		}
    }

}
