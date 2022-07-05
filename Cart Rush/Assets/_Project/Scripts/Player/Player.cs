using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Shelf shelf;
    public List<Orange> CollectedOranges;
    public Transform OrangeStack;
    public int OrangeCount = 0;

    //public bool IsInShelfArea = false;

    private void Start()
    {
        CollectedOranges = new List<Orange>();
        //IsInShelfArea = false;
        OrangeCount = 0;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Shelf") && IsInShelfArea == false)
    //    {
    //        IsInShelfArea = true;
            
    //        Shelf shelf = other.GetComponent<Shelf>();
    //        StartCoroutine(shelf.GiveOrangeWithDelay());
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Shelf") && IsInShelfArea == true)
    //    {
    //        IsInShelfArea = false;
    //        shelf.StopGivingOranges();
    //    }
    //}
}