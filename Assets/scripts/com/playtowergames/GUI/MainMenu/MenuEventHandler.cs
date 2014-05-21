using UnityEngine;
using System.Collections;

public class MenuEventHandler : MonoBehaviour {

    public GameController GameController;
    public UIPanel Panel;

    private Collider _collider;
    void Start()
    {
        _collider = this.collider;
    }

    public void OnStartClick() {

        _collider.enabled = false;
        GameController.StartGame();
    }
}
