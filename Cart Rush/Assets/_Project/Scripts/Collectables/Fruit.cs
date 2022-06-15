using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private Player _player;

    [SerializeField] private int value = 1;
    public int Value => value;

    public void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    public void SendMeToPlayer()
    {
        _player.CollectHandler.AddNewItem(this);
    }

    public void SendMeToCart()
    {
        
    }
}