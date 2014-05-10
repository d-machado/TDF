using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

        public delegate void EnemyInvasionHandler();
        public event EnemyInvasionHandler OnEnemyInvasion;

		public float Speed = 1f;
        public string Path = "enemy_path_1";
		private Hashtable mTweenArgs = null;
		private float mPathPercentageByFrame = 1f;
		private float mCurrentPathPercentage = 0f;
		private bool mReturning = false;

		// Use this for initialization
		void Start ()
		{

		}

        public void putOnPath(string pPath = "", float pStartPercentage = 0f)
        {
            if (pPath == "") { pPath = Path; }
            Path = pPath;

            Vector3[] aPath = iTweenPath.GetPath(Path);

            mPathPercentageByFrame = (Speed / 1000) / aPath.Length;
            mCurrentPathPercentage = pStartPercentage;
            mTweenArgs = new Hashtable();
            mTweenArgs.Add("path", aPath);
            mTweenArgs.Add("speed", Speed);
            mTweenArgs.Add("easetype", iTween.EaseType.linear);

            iTween.PutOnPath(gameObject, aPath, pStartPercentage);
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
                enabled = false;
                Destroy(gameObject);
                OnEnemyInvasion();
			}
			iTween.PutOnPath (gameObject, iTweenPath.GetPath (Path), mCurrentPathPercentage);
		}

		void returningUpdate ()
		{
			mCurrentPathPercentage -= mPathPercentageByFrame;
			if (mCurrentPathPercentage <= 0) {
				mCurrentPathPercentage = 0f;
			}
			iTween.PutOnPath(gameObject, iTweenPath.GetPath(Path), mCurrentPathPercentage);
		}
}
