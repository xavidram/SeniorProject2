using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData {

    public static float _GameDuration = 0;
    public static float _GameRating = 0;

    public static float GameDuration
    {
        get { return _GameDuration; }
        set { _GameDuration = value; }
    }

    public static float GameRating
    {
        get { return _GameRating; }
        set { _GameRating = value; }
    }
}
