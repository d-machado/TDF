using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	public GameObject flag;

	private GameObject aFlag;

	// Use this for initialization
	void Start () {
		aFlag = Instantiate (flag) as GameObject;
		iTween.PutOnPath (aFlag, iTweenPath.GetPath ("enemy_path_main"), .95f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
