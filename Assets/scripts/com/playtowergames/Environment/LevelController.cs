using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	public TowerFactory[] Towers;
	public EnemyDefinition[] Enemies;
    public int Lives = 1;
	
    private GameObject aFlagInstance;
    private GUIUpdater mGuiUpdater;
    private GameController _gameController;
    private WaveController _waveController;
    
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

        aEnemyInstance.GetComponent<Enemy>().SetUIController(mGuiUpdater);

        return aEnemyInstance;
    }

    void Awake()
    {
        _gameController = GameObject.Find("Controller").GetComponent<GameController>();
        _waveController = GetComponent<WaveController>();
    }

	// Use this for initialization
	void Start () {

        _gameController.showUI(GameUIEnum.GAME);
        
        mGuiUpdater = _gameController.getCurrentUI().GetComponent<GUIUpdater>();
		mGuiUpdater.setInitialLives(Lives);

		for(int i = 0; i < Towers.Length; i++){
			Towers[i].OnShowCreationGUIEvent += new TowerFactory.ShowCreationGUIHandler(onShowCreationGUI);
		}
        _waveController.showFirstWave();
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
