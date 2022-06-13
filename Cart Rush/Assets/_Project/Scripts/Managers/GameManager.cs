using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static Enums.GameState currentState;
    public static Enums.GameState CurrentState => currentState;
    
    private UiManager uiManager;
    private void Awake()
    {
        currentState = Enums.GameState.WaitingToStart;
        uiManager = GetComponent<UiManager>();
        uiManager.Init();

        GameEvents.OnGameStart += HandleGameStart;
        GameEvents.OnLevelSuccess += HandleLevelSucces;
        GameEvents.OnLevelFail += HandleLevelFail;
    }
    private void OnDisable()
    {
        GameEvents.OnGameStart -= HandleGameStart;
        GameEvents.OnLevelSuccess -= HandleLevelSucces;
        GameEvents.OnLevelFail -= HandleLevelFail;
    }

    private void HandleLevelFail()
    {
        currentState = Enums.GameState.LevelFail;
    }

    private void HandleLevelSucces()
    {
        currentState = Enums.GameState.LevelSuccess;
    }

    private void HandleGameStart()
    {
        currentState = Enums.GameState.GameStarted;
    }
}
