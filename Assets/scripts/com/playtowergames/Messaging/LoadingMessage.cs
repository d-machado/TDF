using UnityEngine;
using System.Collections;

public class LoadingMessage : MonoBehaviour {

    public UIPanel LoadingPanel;
    public Camera Camera;
    public float FadeStep = .1f;
    public float FadeDuration = -.05f;

    void Awake()
    {
        LoadingPanel.enabled = false;
        Camera.enabled = false;
        LoadingPanel.alpha = 0;
    }

    public void ShowLoadingMessage()
    {
        StopAllCoroutines();
        StartCoroutine(fadePanelIn());
    }

    public void HideLoadingMessage()
    {
        StopAllCoroutines();
        StartCoroutine(fadePanelOut());
    }

    IEnumerator fadePanelOut()
    {
        while (LoadingPanel.alpha > 0)
        {
            LoadingPanel.alpha -= FadeStep;
            yield return new WaitForSeconds(FadeDuration);
        }
        LoadingPanel.enabled = false;
        Camera.enabled = false;
    }

    IEnumerator fadePanelIn()
    {
        Camera.enabled = true;
        LoadingPanel.enabled = true;
        while (LoadingPanel.alpha < 1)
        {
            LoadingPanel.alpha += FadeStep;
            yield return new WaitForSeconds(FadeDuration);
        }
    }
}
