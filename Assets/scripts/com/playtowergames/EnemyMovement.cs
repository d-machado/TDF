using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

		public float Speed = 1f;
		private Hashtable mTweenArgs = null;
		private float mPathPercentageByFrame = 1f;
		private float mCurrentPathPercentage = 0f;
		private bool mReturning = false;

		// Use this for initialization
		void Start ()
		{

				Vector3[] aPath = iTweenPath.GetPath ("enemy_path_1");

				mPathPercentageByFrame = (Speed / 1000) / aPath.Length;

				mTweenArgs = new Hashtable ();
				mTweenArgs.Add ("path", aPath);
				mTweenArgs.Add ("speed", Speed);
				mTweenArgs.Add ("easetype", iTween.EaseType.linear);

				iTween.PutOnPath (gameObject, aPath, 0f);

				Invoke("revertPath", 10);
		}

		void revertPath ()
		{
			Debug.Log("invoke");
			mReturning = true;
		}

		// Update is called once per frame
		void Update ()
		{

				if (mReturning == false) {
					advanceUpdate ();
				} else {
					returningUpdate();
				}
		 
		}

		void advanceUpdate ()
		{
			mCurrentPathPercentage += mPathPercentageByFrame;
			if (mCurrentPathPercentage >= 1) {
				mCurrentPathPercentage = 1f;
			}
			iTween.PutOnPath (gameObject, iTweenPath.GetPath ("enemy_path_1"), mCurrentPathPercentage);
		}

		void returningUpdate ()
		{
			mCurrentPathPercentage -= mPathPercentageByFrame;
			if (mCurrentPathPercentage <= 0) {
				mCurrentPathPercentage = 0f;
			}
			iTween.PutOnPath(gameObject, iTweenPath.GetPath("enemy_path_1"), mCurrentPathPercentage);
		}
}
