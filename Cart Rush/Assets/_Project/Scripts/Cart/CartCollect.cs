using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartCollect : MonoBehaviour
{
    [Header("-- SETUP --")]
    [SerializeField] private Player player;
    [SerializeField] private Transform releasePoint;

    [SerializeField] private List<GameObject> collectables = new List<GameObject>();

    private int collectableCapacity = 96;
    private int collectableCount = 0;
    private int _rowNumber, _columnNumber, _heightNumber = 0;

    private float _rowOffset = 0.25f;
    private float _columnOffset = -0.25f;
    private float _heightOffset = 0.25f;

    private int _rowLength = 6;
    private int _columnLength = 6;

    private bool playerIsInArea = false;

    private void CollectCollectable()
    {
        if (player.oranges.Count > 0 && collectableCount < collectableCapacity)
        {
            GameObject collectable = player.oranges[player.oranges.Count - 1];
            collectables.Add(collectable);
            player.oranges.Remove(collectable);
            collectable.transform.SetParent(releasePoint);
            Vector3 offset = new Vector3(_columnOffset * _columnNumber, _heightNumber * _heightOffset, _rowOffset * _rowNumber);
            collectable.transform.position = releasePoint.position + offset;

            player.orangeCount--;
            collectableCount++;

            CheckOffsetValuesForCollect();
            player.CheckOffsetValuesForOnceAgainCollect();
        }
    }

    private void CheckOffsetValuesForCollect()
    {
        {
            _rowNumber++;

            if (_rowNumber == _rowLength)
            {
                _rowNumber = 0;
                _columnNumber++;
            }

            if (_columnNumber == _columnLength)
            {
                _columnNumber = 0;
                _heightNumber++;
            }
        }
    }

    private IEnumerator CollectCollectableWithDelay()
    {
        while (player.orangeCount >= 0 && playerIsInArea == true)
        {
            CollectCollectable();
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CollectableBase collectable = other.GetComponent<CollectableBase>();

        if (collectable != null && playerIsInArea == false)
        {
            playerIsInArea = true;
            StartCoroutine(CollectCollectableWithDelay());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (playerIsInArea == true)
        {
            playerIsInArea = false;
        }
    }
}
