using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameState { Menu, Game, LevelComplate, GameOver }

    private GameState gameState;

    public static Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance);
        else
            Instance = this;
    }

    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        OnGameStateChanged?.Invoke(gameState);

        Debug.Log("Game State changed to : " + gameState);
    }

    public bool IsGameState()
    {
        return gameState == GameState.Game;
    }
}
