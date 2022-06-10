using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [Header("-- REFERENCES --")]
    [SerializeField] private TouchToStart touchToStart;

    public void Init()
    {
        touchToStart.gameObject.SetActive(true);

        GameEvents.OnGameStart += HandleGameStart;
    }
    private void OnDisable()
    {
        GameEvents.OnGameStart -= HandleGameStart;
    }

    private void HandleGameStart()
    {
        touchToStart.gameObject.SetActive(false);
    }
}
