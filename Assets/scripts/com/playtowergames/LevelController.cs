using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	public GameObject flag;

	private GameObject aFlagInstance;
    
	// Use this for initialization
	void Start () {
		aFlagInstance = Instantiate (flag) as GameObject;
        iTween.PutOnPath (aFlagInstance, iTweenPath.GetPath ("enemy_path_main"), .95f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
