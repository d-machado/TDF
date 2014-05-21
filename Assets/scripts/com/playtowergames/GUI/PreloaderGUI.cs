using UnityEngine;
using System.Collections;

public class PreloaderGUI : MonoBehaviour {

    public string PlayerURL = "http://playtowergames.com/custom_games/tdf/current/tdf.unity3d";
    public UILabel LoadingText;

    private WWW stream;
    void Awake()
    {
        
    }

	void Start () {

        stream = new WWW(PlayerURL);
        StartCoroutine(LoadingProgress());
	}

    private IEnumerator LoadingProgress()
    {
        while (!stream.isDone)
        {
            Debug.Log("Loading");
            LoadingText.text = "LOADING " + (int)(stream.progress * 100) + "%";
            yield return new WaitForEndOfFrame();
        }
        stream.LoadUnityWeb();
    }
	
	
}
