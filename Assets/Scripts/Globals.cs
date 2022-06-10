using UnityEngine;

public enum GameState
{
    HOME, PLAYING, VICTORY, DEFEAT
}


public static class Global
{
    public static float DeltaTime => Time.deltaTime * TimeScale;
    public static float TimeScale {get; set;} = 1f;

}

public static class Level 
{
    public static float ObjectSpeed {get; set;} = 5;

}