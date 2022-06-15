using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    private int fruit;
    public int Fruit => fruit;
    public Transform itemHolderTransform;
    private List<Fruit> collectedFruit = new List<Fruit>();

    public void AddNewItem(Fruit fruitToAdd)
    {
        collectedFruit.Add(fruitToAdd);

        fruitToAdd.transform.SetParent(itemHolderTransform, true);
        fruitToAdd.transform.localPosition = new Vector3(0, 0.25f * fruit, 0.63f);
        fruitToAdd.transform.localRotation = Quaternion.identity;

        PlayerEvents.OnCollectFruit?.Invoke(fruitToAdd.Value);
    }
    public void Init()
    {
        fruit = 0;
        collectedFruit.Clear();
        PlayerEvents.OnCollectFruit += HandleCollectFruit;
    }
    private void OnDisable()
    {
        PlayerEvents.OnCollectFruit -= HandleCollectFruit;
    }

    private void HandleCollectFruit(int fruitCount)
    {
        fruit += fruitCount;
    }
}
