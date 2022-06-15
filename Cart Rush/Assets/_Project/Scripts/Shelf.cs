using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    [SerializeField] private Fruit fruit; 

    private bool playerIsInside = false;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null && playerIsInside == false)
        {
            GiveFruit();
            playerIsInside = true;
            Debug.Log("mevye vermeye basla");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null && playerIsInside == true)
        {
            playerIsInside = false;
            Debug.Log("mevye vermeyi durdur");
        }
    }

    private void GiveFruit()
    {
        fruit.SendMeToPlayer();
    }
}
