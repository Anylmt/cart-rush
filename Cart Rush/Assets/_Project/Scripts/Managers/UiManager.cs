using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [Header("-- REFERENCES --")]
    [SerializeField] private TouchToStart touchToStart;
    [SerializeField] private LevelSuccess levelSucces;
    [SerializeField] private LevelFail levelFail;

    public void Init()
    {
        touchToStart.gameObject.SetActive(true);

        levelSucces.gameObject.SetActive(false);

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
        levelFail.gameObject.SetActive(true);
    }

    private void HandleLevelSucces()
    {
        levelSucces.gameObject.SetActive(true);
    }

    private void HandleGameStart()
    {
        touchToStart.gameObject.SetActive(false);
    }
}
