using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public GameState gameState;

    public static event Action<GameState> OnGameStateChanged;
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public static GameManager Instance()
    {
        return instance;
    }

    private void Start()
    {
        UpdateGameState(GameState.MainMenu);
        AudioManager.Instance().PlayBGM("bgm1");
    }

    public void UpdateGameState(GameState newState)
    {
        gameState = newState;
        OnGameStateChanged?.Invoke(gameState);
    }
}

public enum GameState {
    MainMenu,
    CharacterManagement,
    PlayGame,
    SpawnUnit,
    PlayerTurn,
    EnemyTurn,
    Victory,
    Defeat,
}
