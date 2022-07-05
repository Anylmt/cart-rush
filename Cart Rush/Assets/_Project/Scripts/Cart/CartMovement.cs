using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartMovement : MonoBehaviour
{
    [SerializeField] private float cartMovementSpeed = 1f;
    private void Update()
    {
        if(GameManager.CurrentState == Enums.GameState.GameStarted)
        {
            transform.Translate(0, 0, cartMovementSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish") && GameManager.CurrentState == Enums.GameState.GameStarted)
        {
            GameEvents.OnLevelSuccess?.Invoke();
        }
        
        if (other.CompareTag("Enemy") && GameManager.CurrentState == Enums.GameState.GameStarted)
        {
            GameEvents.OnLevelFail?.Invoke();
        }
    }
}
