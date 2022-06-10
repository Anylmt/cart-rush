using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToStart : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(GameManager.CurrentState != Enums.GameState.GameStarted)
            {
                GameEvents.OnGameStart?.Invoke();
            }
        }
    }
}
