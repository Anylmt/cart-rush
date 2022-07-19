using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTouch : MonoBehaviour
{
    [SerializeField] private bool _isInArea = false;

    public void EnemyTouchCart()
    {
        if (_isInArea == false)
        {
            _isInArea = true;
        }
    }
}
