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
    }
    private void OnDisable()
    {
        GameEvents.OnGameStart -= HandleGameStart;
    }

    private void HandleGameStart()
    {
        currentState = Enums.GameState.GameStarted;
    }
}
