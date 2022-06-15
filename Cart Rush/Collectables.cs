using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    private int fruit;
    public int Fruit => fruit;

    public Transform ItemHoldersTransform;
    private List<Fruit> collectedFruit = new List<Fruit>();

    public void AddNewItem(Fruit fruitToAdd)
    {
        collectedFruit.Add(fruitToAdd);

        fruitToAdd.transform.SetParent(ItemHoldersTransform, true);
        fruitToAdd.transform.localPosition = new Vector3(0, 0.2f * fruit, 0.3f);
        fruitToAdd.transform.localRotation = Quaternion.identity;
    }
}
