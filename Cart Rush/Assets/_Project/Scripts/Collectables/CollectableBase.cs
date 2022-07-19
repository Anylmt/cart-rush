using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    [SerializeField] private bool _isCollected = false;

    public void GetCollected()
    {
        if (_isCollected == false)
        {
            _isCollected = true;
        }
    }
}
