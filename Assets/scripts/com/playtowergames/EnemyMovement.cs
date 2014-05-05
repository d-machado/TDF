using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float Speed = 1f;

	private Hashtable mTweenArgs = null;
	private iTween mTween;

	// Use this for initialization
	void Start () {

		mTweenArgs = new Hashtable();
		mTweenArgs.Add("path", iTweenPath.GetPath("enemy_path_1"));
		mTweenArgs.Add("speed", Speed);
		mTweenArgs.Add ("easetype", iTween.EaseType.linear);

		mTween = new iTween();
	
		mTween.MoveTo(gameObject, mTweenArgs);


		Invoke("revertPath", 10);
	}

	void revertPath(){
		/*print("test");
		mTweenArgs["path"] = iTweenPath.GetPathReversed("enemy_path_1");
		iTween.Stop();
		iTween.PutOnPath(gameObject, iTweenPath.GetPathReversed("enemy_path_1"), .3f);
		iTween.MoveTo(gameObject, mTweenArgs);*/
	}

	// Update is called once per frame
	void Update () {
	
	}
}
