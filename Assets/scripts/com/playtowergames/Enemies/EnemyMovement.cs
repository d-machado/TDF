using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    public delegate void EnemyInvasionHandler();
    public event EnemyInvasionHandler OnEnemyInvasionEvent;

    public float MinSpeed = .2f;
    public float MaxSpeed = 1.4f;
    public float Speed = 1f;
    public bool UseFixedSpeed = false;
    public string Path = "enemy_path_1";


    private Hashtable mTweenArgs = null;
    private float mPathPercentageByFrame = 1f;
    private float mCurrentPathPercentage = 0f;
    private int mCurrentWaypointIndex = 1;
    private float _percentageByWaypoint = 0f;
    private float _percentageUntilNextWaypoint = 0f;
    private Vector3[] _path;
    private bool mReturning = false;

    // Use this for initialization
    void Start()
    {
        if (!UseFixedSpeed)
        {
            Speed = Random.Range(MinSpeed, MaxSpeed);
        }
    }

    public void putOnPath(string pPath = "", float pStartPercentage = 0f)
    {
        if (pPath == "") { pPath = Path; }
        Path = pPath;

        _path = iTweenPath.GetPath(Path);

        _percentageByWaypoint = 1f / _path.Length;
        _percentageUntilNextWaypoint = _percentageByWaypoint;
        mPathPercentageByFrame = (Speed / 1000) / _path.Length;
        mCurrentPathPercentage = pStartPercentage;
        mTweenArgs = new Hashtable();
        mTweenArgs.Add("path", _path);
        mTweenArgs.Add("speed", Speed);
        mTweenArgs.Add("easetype", iTween.EaseType.linear);

        iTween.PutOnPath(gameObject, _path, pStartPercentage);
        
    }

    void revertPath()
    {
        Debug.Log("invoke");
        mReturning = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (mReturning == false)
        {
            advanceUpdate();
        }
        else
        {
            returningUpdate();
        }

    }

    void advanceUpdate()
    {
        mCurrentPathPercentage += mPathPercentageByFrame;
        if (mCurrentPathPercentage >= 1)
        {
            mCurrentPathPercentage = 1f;
            enabled = false;
            Destroy(gameObject);
            if (OnEnemyInvasionEvent != null) { OnEnemyInvasionEvent(); }
        }
        
        iTween.PutOnPath(gameObject, _path, mCurrentPathPercentage);
        Vector3 aTarget = iTween.PointOnPath(_path, mCurrentPathPercentage + .05f);
        transform.LookAt(aTarget);
    }

    void returningUpdate()
    {
        mCurrentPathPercentage -= mPathPercentageByFrame;
        if (mCurrentPathPercentage <= 0)
        {
            mCurrentPathPercentage = 0f;
        }
        iTween.PutOnPath(gameObject, _path, mCurrentPathPercentage);
    }
}
