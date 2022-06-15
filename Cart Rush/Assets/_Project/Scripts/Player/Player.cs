using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerCollect _collectHandler;
    public PlayerCollect CollectHandler => _collectHandler;
    private void Awake()
    {
        _collectHandler = GetComponent<PlayerCollect>();

        _collectHandler.Init();
    }
}