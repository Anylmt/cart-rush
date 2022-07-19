using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("-- SETUP --")]
    public Transform orangeStacktPoint;

    public List<GameObject> oranges = new List<GameObject>();

    public int orangeCapacity = 8;
    public int orangeCount = 0;
    public int _rowNumber, _columnNumber, _heightNumber = 0;

    //public float _rowOffset = 0.25f;
    public float _columnOffset = -0.25f;
    public float _heightOffset = 0.25f;

    public int _rowLength = 2;
    public int _columnLength = 4;
    public int _heightLength = 4;
    private void Start()
    {
        oranges.Clear();
    }

    public void CheckOffsetValuesForCollect()
    {
        _heightNumber++;

        if (_heightNumber == _heightLength)
        {
            _heightNumber = 0;
            _columnNumber++;
        }

        if (_columnNumber == _columnLength)
        {
            _columnNumber = 0;
            _rowNumber++;
        }
    }

    public void CheckOffsetValuesForOnceAgainCollect()
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
}