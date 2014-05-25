using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	public TowerFactory[] Towers;
	public EnemyDefinition[] Enemies;
    public int Lives = 1;
	private GameObject aFlagInstance;
    private GUIUpdater mGuiUpdater;
    private GameController _gameController;
    
    public GameObject GetNewInstanceOfEnemy(EnemyTypesEnum aType)
    {
        EnemyDefinition aEnemy = null;
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
        return aEnemyInstance;
    }

	// Use this for initialization
	void Start () {

        _gameController = GameObject.Find("Controller").GetComponent<GameController>();
        _gameController.showUI(GameUIEnum.GAME);

		mGuiUpdater = _gameController.getCurrentUI().GetComponent<GUIUpdater>();
		mGuiUpdater.setInitialLives(Lives);

		for(int i = 0; i < Towers.Length; i++){
			Towers[i].OnShowCreationGUIEvent += new TowerFactory.ShowCreationGUIHandler(onShowCreationGUI);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void onShowCreationGUI(TowerFactory aTowerFactory){
		mGuiUpdater.showConstructionGUI(aTowerFactory);
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
