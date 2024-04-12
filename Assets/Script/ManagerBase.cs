using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerBase : MonoBehaviour
{
    void Awake()
    {
        GameManager.OnGameStateChanged += OnGameStateChanged; //subscribe
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= OnGameStateChanged; //unsubscribe
    }

    protected virtual void OnGameStateChanged(GameState state)
    {

    }
}
