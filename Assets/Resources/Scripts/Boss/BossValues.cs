using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossValues {

    public static float _Health = 200;
    public static float _MaxHealth = 200;
    public static float _Speed = 2f;
    public static float _Armor = 10f;

    public static float _DamageTaken = 0;
    public static float _DamageDealt = 0;

    //  Q Ability Data
    public static List<string> _QAbilityBehaviours;
    public static float _QAbilityCasts = 0;
    public static float _QAbilityHits = 0;
    //  W Ability Data
    public static string _WAbilityName;
    public static float _WAbilityCasts = 0;
    public static float _WAbilityHits = 0;
    //  E Ability Data
    public static string _EAbilityName;
    public static float _EAbilityCasts = 0;
    public static float _EAbilityHits = 0;

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

    public static float DamageTaken
    {
        get { return _DamageTaken; }
        set { _DamageTaken = value; }
    }

    public static float DamageDealt
    {
        get { return _DamageDealt; }
        set { _DamageDealt = value; }
    }

    public static List<string> QAbilityBehaviors
    {
        get { return _QAbilityBehaviours; }
        set { _QAbilityBehaviours = value; }
    }

    public static float QAbilityCasts
    {
        get { return _QAbilityCasts; }
        set { _QAbilityCasts = value; }
    }

    public static float QAbilityHits
    {
        get { return _QAbilityHits; }
        set { _QAbilityHits = value; }
    }

    public static string WAbilityName
    {
        get { return _WAbilityName; }
        set { _WAbilityName = value; }
    }

    public static float WAbilityCasts
    {
        get { return _WAbilityCasts; }
        set { _WAbilityCasts = value; }
    }

    public static float WAbilityHits
    {
        get { return _WAbilityHits; }
        set { _WAbilityHits = value; }
    }

    public static string EAbilityName
    {
        get { return _EAbilityName; }
        set { _EAbilityName = value; }
    }

    public static float EAbilityCasts
    {
        get { return _EAbilityCasts; }
        set { _EAbilityCasts = value; }
    }

    public static float EAbilityHits
    {
        get { return _EAbilityHits; }
        set { _EAbilityHits = value; }
    }
}
