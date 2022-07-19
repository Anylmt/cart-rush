using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartMovement : MonoBehaviour
{
    [SerializeField] private float cartMovementSpeed = 1f;
    [SerializeField] private bool enemyIsInArea = false;

    private void Update()
    {
        if (GameManager.CurrentState == Enums.GameState.GameStarted)
        {
            transform.Translate(0, 0, cartMovementSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        EnemyTouch enemy = other.GetComponent<EnemyTouch>();

        if (other.CompareTag("Finish") && GameManager.CurrentState == Enums.GameState.GameStarted)
        {
            GameEvents.OnLevelSuccess?.Invoke();
        }

        if (enemy != null && enemyIsInArea == false && GameManager.CurrentState == Enums.GameState.GameStarted)
        {
            enemy.EnemyTouchCart();
            enemyIsInArea = true;
            GameEvents.OnLevelFail?.Invoke();
        }
    }
}
