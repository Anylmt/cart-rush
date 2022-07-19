using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rack : MonoBehaviour
{
    [Header("-- SETUP --")]
    [SerializeField] private Player player;
    [SerializeField] private GameObject collectablePrefab;
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private List<GameObject> oranges = new List<GameObject>();

    private int collectableCapacity = 32;
    private int collectableCount = 0;
    private int _rowNumber, _columnNumber, _heightNumber = 0;

    private float _rowOffset = 0.25f;
    private float _columnOffset = -0.25f;
    private float _heightOffset = 0.25f;

    private int _rowLength = 4;
    private int _columnLength = 4;

    private bool _playerIsInThisArea = false;

    private void Start()
    {
        oranges.Clear();
        StartCoroutine(SpawnCollectable());
    }

    private IEnumerator SpawnCollectable()
    {
        while (true)
        {
            if (collectableCount < collectableCapacity && GameManager.CurrentState == Enums.GameState.GameStarted)
            {
                GameObject collectable = Instantiate(collectablePrefab);
                oranges.Add(collectable);
                collectable.transform.SetParent(spawnPoint);
                Vector3 spawnOffset = new Vector3(_columnNumber * _columnOffset, _heightNumber * _heightOffset, _rowNumber * _rowOffset);
                collectable.transform.localPosition = Vector3.zero + spawnOffset;

                collectableCount++;

                CheckOffsetValuesForSpawn();
            }

            yield return new WaitForSeconds(1f);
        }
    }
    private void CheckOffsetValuesForSpawn()
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

    public void SpendCollectable()
    {
        if (oranges.Count > 0 && player.orangeCount < player.orangeCapacity)
        {
            GameObject collectable = oranges[oranges.Count - 1];

            player.oranges.Add(collectable);
            oranges.Remove(collectable);
            collectable.transform.SetParent(player.orangeStacktPoint);
            Vector3 spendOffset = new Vector3(player._columnNumber * player._columnOffset, player._heightNumber * player._heightOffset, 0);
            collectable.transform.position = player.orangeStacktPoint.position + spendOffset;

            player.orangeCount++;
            collectableCount--;

            CheckOffsetValuesForSpend();
            player.CheckOffsetValuesForCollect();
        }
    }

    private void CheckOffsetValuesForSpend()
    {
        if (_rowNumber == 0)
        {
            if (_columnNumber == 0 && _heightNumber > 0)
            {
                _heightNumber--;
                _columnNumber = _columnLength - 1;
                _rowNumber = _rowLength;
            }
            else
            {
                _columnNumber--;
                _rowNumber = _rowLength;
            }
        }

        _rowNumber--;
    }

    public IEnumerator SpendCollectableWithDelay()
    {
        while (oranges.Count >= 0 && _playerIsInThisArea == true)
        {
            SpendCollectable();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CollectableBase collectable = other.GetComponent<CollectableBase>();

        if (collectable != null && _playerIsInThisArea == false)
        {
            _playerIsInThisArea = true;
            //collectable.GetCollected();
            StartCoroutine(SpendCollectableWithDelay());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (_playerIsInThisArea == true)
        {
            _playerIsInThisArea = false;
        }
    }
}
