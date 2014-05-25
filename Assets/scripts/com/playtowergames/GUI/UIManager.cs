using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIManager {

    private UIAnchor _anchor;

    private UIPanel _currentShowingUI;
    private GameUIEnum _currentShowingUIType;
    private Dictionary<GameUIEnum, UIPanel> _UIPrefabs;

    public UIManager(UIAnchor aAnchor, Dictionary<GameUIEnum, UIPanel> aUIPrefabs)
    {
        _anchor = aAnchor;
        _UIPrefabs = aUIPrefabs;
    }

    public void showUI(GameUIEnum aUIType)
    {
        //Check if not the same ui
        if (_currentShowingUIType != aUIType)
        {
            //Check if the new ui exist
            if (_UIPrefabs.ContainsKey(aUIType))
            {
                //Remove current ui
                RemoveCurrentUI();
                //Add new ui
                AddNewGui(_UIPrefabs[aUIType], aUIType);
            }
            
        }
    }

    public void hideCurrentUI()
    {
        RemoveCurrentUI();
    }

    public UIPanel getCurrentUI()
    {
        return _currentShowingUI;
    }

    private void RemoveCurrentUI()
    {
        if (_currentShowingUI != null)
        {
            _currentShowingUI.transform.parent = null;
            Object.Destroy(_currentShowingUI);
        }
    }

    private void AddNewGui(UIPanel aUIPrefab, GameUIEnum aType)
    {
        UIPanel aNewPanel = GameObject.Instantiate(aUIPrefab) as UIPanel;
        aNewPanel.transform.parent = _anchor.transform;
        aNewPanel.transform.localScale = Vector3.one;
        aNewPanel.transform.localPosition = Vector3.zero;
        _currentShowingUI = aNewPanel;
        _currentShowingUIType = aType;
    }
}
