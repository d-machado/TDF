using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private LoadingMessage _loadingMessage;

    void Awake()
    {
        DontDestroyOnLoad(this);
        _loadingMessage = GetComponent<LoadingMessage>();
    }

    public void StartGame()
    {
        Application.LoadLevel(1);

        if (Application.GetStreamProgressForLevel(1) < 1)
        {
            StartCoroutine(showLevelLoader(1));
        }
    }

    IEnumerator showLevelLoader(int level)
    {
        if (Application.GetStreamProgressForLevel(level) < 1)
        {
            _loadingMessage.ShowLoadingMessage();
            while (Application.GetStreamProgressForLevel(level) < 1)
            {
                yield return new WaitForEndOfFrame();
            }
            _loadingMessage.HideLoadingMessage();
        }
        
    }

}
