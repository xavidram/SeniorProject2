using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossValues {

    public static float _Health = 200;
    public static float _MaxHealth = 200;
    public static float _Speed = 1f;
    public static float _Armor = 10f;

    //  Limit what variables can be overwritten or only read
    public static float Health
    {
        get { return _Health; }
        set { _Health = value; }
    }
    public static float MaxHealth
    {
        get { return _MaxHealth; }
    }
    public static float Speed
    {
        get { return _Speed; }
        set { _Speed = value; }
    }
    public static float Armor
    {
        get { return _Armor; }
        set { _Armor = value; }
    }
}
