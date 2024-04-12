using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : ManagerBase
{
    [SerializeField]
    GameObject playerInteractiveUIContainer;
    protected override void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.PlayerTurn:
                playerInteractiveUIContainer.SetActive(true);
                break;
            case GameState.EnemyTurn:
                playerInteractiveUIContainer.SetActive(false);
                break;
            default: break;
        }
    }
}
