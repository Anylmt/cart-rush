using System;

public class EventManager { }
public static class GameEvents
{
    public static Action OnGameStart, OnLevelSuccess, OnLevelFail;
}
public static class PlayerEvents
{
    public static Action<int> OnCollectFruit;
}
