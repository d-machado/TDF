using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{

    #region UI Prefabs
    public UIPanel MainMenuUIPrefab;
    public UIPanel LoadingMessageUIPrefab;
    public UIPanel InGameUIPrefab;
    #endregion

    public UIAnchor Anchor;

    private UIManager _uiManager;

    void Awake()
    {
        DontDestroyOnLoad(this);
        
        Dictionary<GameUIEnum, UIPanel> aUIPrefabs = new Dictionary<GameUIEnum, UIPanel>();
        aUIPrefabs.Add(GameUIEnum.LOADER, LoadingMessageUIPrefab);
        aUIPrefabs.Add(GameUIEnum.MAIN_MENU, MainMenuUIPrefab);
        aUIPrefabs.Add(GameUIEnum.GAME, InGameUIPrefab);

        _uiManager = new UIManager(Anchor, aUIPrefabs);
    }

    public void showUI(GameUIEnum aUIType)
    {
        _uiManager.showUI(aUIType);
    }

    public UIPanel getCurrentUI()
    {
        return _uiManager.getCurrentUI();
    }

    public void StartGame()
    {
        _uiManager.showUI(GameUIEnum.LOADER);
        Application.LoadLevel(1);
        _uiManager.hideCurrentUI();
    }

}
