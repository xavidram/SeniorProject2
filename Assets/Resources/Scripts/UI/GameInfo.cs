using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo {

    public float _GameDuration = 0;
    public float _GameRating = 0;

    //  Player Data
    public float Player_Health = 100;
    public float Player_MaxHealth = 100;
    public float Player_Speed = 2.5f;
    public float Player_Armor = 10f;

    public float Player_DamageTaken = 0;
    public float Player_DamageDealt = 0;

    //  Q Ability Data
    public List<string> Player_QAbilityBehaviours;
    public float Player_QAbilityCasts = 0;
    public float Player_QAbilityHits = 0;
    //  W Ability Data
    public string Player_WAbilityName;
    public float Player_WAbilityCasts = 0;
    public float Player_WAbilityHits = 0;
    //  E Ability Data
    public string Player_EAbilityName;
    public float Player_EAbilityCasts = 0;
    public float Player_EAbilityHits = 0;
    // R Ability Data
    public string Player_RAbilityName;
    public float Player_RAbilityCasts = 0;
    public float Player_RAbilityHits = 0;

    //  Boss Data
    public static float Boss_Health = 200;
    public static float Boss_MaxHealth = 200;
    public static float Boss_Speed = 2f;
    public static float Boss_Armor = 10f;

    public static float Boss_DamageTaken = 0;
    public static float Boss_DamageDealt = 0;

    //  Q Ability Data
    public static List<string> Boss_QAbilityBehaviours;
    public static float Boss_QAbilityCasts = 0;
    public static float Boss_QAbilityHits = 0;
    //  W Ability Data
    public static string Boss_WAbilityName;
    public static float Boss_WAbilityCasts = 0;
    public static float Boss_WAbilityHits = 0;
    //  E Ability Data
    public static string Boss_EAbilityName;
    public static float Boss_EAbilityCasts = 0;
    public static float Boss_EAbilityHits = 0;

    public float GameDuration
    {
        get { return _GameDuration; }
        set { _GameDuration = value; }
    }

    public float GameRating
    {
        get { return _GameRating; }
        set { _GameRating = value; }
    }

    // Player Getters
    //  Limit what variables can be overwritten or only read
    public float PlayerHealth
    {
        get { return Player_Health; }
        set { Player_Health = value; }
    }
    public float PlayerMaxHealth
    {
        get { return Player_MaxHealth; }
        set { Player_MaxHealth = value; }
    }
    public float PlayerSpeed
    {
        get { return Player_Speed; }
        set { Player_Speed = value; }
    }
    public float PlayerArmor
    {
        get { return Player_Armor; }
        set { Player_Armor = value; }
    }

    public float PlayerDamageTaken
    {
        get { return Player_DamageTaken; }
        set { Player_DamageTaken = value; }
    }

    public float PlayerDamageDealt
    {
        get { return Player_DamageDealt; }
        set { Player_DamageDealt = value; }
    }

    public List<string> PlayerQAbilityBehaviors
    {
        get { return Player_QAbilityBehaviours; }
        set { Player_QAbilityBehaviours = value; }
    }

    public float PlayerQAbilityCasts
    {
        get { return Player_QAbilityCasts; }
        set { Player_QAbilityCasts = value; }
    }

    public float PlayerQAbilityHits
    {
        get { return Player_QAbilityHits; }
        set { Player_QAbilityHits = value; }
    }

    public string PlayerWAbilityName
    {
        get { return Player_WAbilityName; }
        set { Player_WAbilityName = value; }
    }

    public float PlayerWAbilityCasts
    {
        get { return Player_WAbilityCasts; }
        set { Player_WAbilityCasts = value; }
    }

    public float PlayerWAbilityHits
    {
        get { return Player_WAbilityHits; }
        set { Player_WAbilityHits = value; }
    }

    public string PlayerEAbilityName
    {
        get { return Player_EAbilityName; }
        set { Player_EAbilityName = value; }
    }

    public float PlayerEAbilityCasts
    {
        get { return Player_EAbilityCasts; }
        set { Player_EAbilityCasts = value; }
    }

    public float PlayerEAbilityHits
    {
        get { return Player_EAbilityHits; }
        set { Player_EAbilityHits = value; }
    }

    public string PlayerRAbilityName
    {
        get { return Player_RAbilityName; }
        set { Player_RAbilityName = value; }
    }

    public float PlayerRAbilityCasts
    {
        get { return Player_RAbilityCasts; }
        set { Player_RAbilityCasts = value; }
    }

    public float PlayerRAbilityHits
    {
        get { return Player_RAbilityHits; }
        set { Player_RAbilityHits = value; }
    }

    //Boss Getters
    public float BossHealth
    {
        get { return Boss_Health; }
        set { Boss_Health = value; }
    }
    public float BossMaxHealth
    {
        get { return Boss_MaxHealth; }
        set { Boss_MaxHealth = value; }
    }
    public float BossSpeed
    {
        get { return Boss_Speed; }
        set { Boss_Speed = value; }
    }
    public float BossArmor
    {
        get { return Boss_Armor; }
        set { Boss_Armor = value; }
    }

    public float BossDamageTaken
    {
        get { return Boss_DamageTaken; }
        set { Boss_DamageTaken = value; }
    }

    public float BossDamageDealt
    {
        get { return Boss_DamageDealt; }
        set { Boss_DamageDealt = value; }
    }

    public List<string> BossQAbilityBehaviors
    {
        get { return Boss_QAbilityBehaviours; }
        set { Boss_QAbilityBehaviours = value; }
    }

    public float BossQAbilityCasts
    {
        get { return Boss_QAbilityCasts; }
        set { Boss_QAbilityCasts = value; }
    }

    public float BossQAbilityHits
    {
        get { return Boss_QAbilityHits; }
        set { Boss_QAbilityHits = value; }
    }

    public string BossWAbilityName
    {
        get { return Boss_WAbilityName; }
        set { Boss_WAbilityName = value; }
    }

    public float BossWAbilityCasts
    {
        get { return Boss_WAbilityCasts; }
        set { Boss_WAbilityCasts = value; }
    }

    public float BossWAbilityHits
    {
        get { return Boss_WAbilityHits; }
        set { Boss_WAbilityHits = value; }
    }

    public string BossEAbilityName
    {
        get { return Boss_EAbilityName; }
        set { Boss_EAbilityName = value; }
    }

    public float BossEAbilityCasts
    {
        get { return Boss_EAbilityCasts; }
        set { Boss_EAbilityCasts = value; }
    }

    public float BossEAbilityHits
    {
        get { return Boss_EAbilityHits; }
        set { Boss_EAbilityHits = value; }
    }

}
