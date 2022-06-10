using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartMovement : MonoBehaviour
{
    [SerializeField] private float cartMovementSpeed = 1f;
    private void Update()
    {
        transform.Translate(0, 0, cartMovementSpeed * Time.deltaTime);
    }
}
