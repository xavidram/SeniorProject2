using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCtrl : MonoBehaviour {

    private string URL;

    void Start()
    {
        URL = "104.236.219.147/saveData/";
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
	
    public void setRating(int value)
    {
        // set the rating
        GameData.GameRating = value;
        //call function to send all the data
        //pushData();
        UnityEngine.Debug.Log(GameData.GameRating.ToString());
    }

    //push all the data to the rest api
    public void pushData()
    {
        //  Game Form to be sent to api
        WWWForm gameInformation = new WWWForm();
        //  Add Player Data
        gameInformation.AddField("pHealth", PlayerValues.Health.ToString());
        gameInformation.AddField("pMaxHealth", PlayerValues.MaxHealth.ToString());
        gameInformation.AddField("pQBehaviors", PlayerValues.QAbilityBehaviors.ToString());
        gameInformation.AddField("pQCastCount", PlayerValues.QAbilityCasts.ToString());
        gameInformation.AddField("pQCastHits", PlayerValues.QAbilityHits.ToString());
        gameInformation.AddField("pWAbility", PlayerValues.WAbilityName.ToString());
        gameInformation.AddField("pWCastCount", PlayerValues.WAbilityCasts.ToString());
        gameInformation.AddField("pWCastHits", PlayerValues.WAbilityHits.ToString());
        gameInformation.AddField("pEAbility", PlayerValues.EAbilityName.ToString());
        gameInformation.AddField("pECastCount", PlayerValues.EAbilityCasts.ToString());
        gameInformation.AddField("pECastHits", PlayerValues.EAbilityHits.ToString());
        gameInformation.AddField("pRAbility", PlayerValues.RAbilityName.ToString());
        gameInformation.AddField("pRCastCount", PlayerValues.RAbilityCasts.ToString());
        gameInformation.AddField("PRCastHits", PlayerValues.RAbilityHits.ToString());
        gameInformation.AddField("pDamageTaken", PlayerValues.DamageTaken.ToString());
        gameInformation.AddField("pDamageDealt", PlayerValues.DamageDealt.ToString());
        gameInformation.AddField("pSpeed", PlayerValues.Speed.ToString());
        gameInformation.AddField("pArmor", PlayerValues.Armor.ToString());
        //  Grab boss data and serialize it
        gameInformation.AddField("bHealth", BossValues.Health.ToString());
        gameInformation.AddField("bMaxHealth", BossValues.MaxHealth.ToString());
        gameInformation.AddField("bQBehaviors", BossValues.QAbilityBehaviors.ToString());
        gameInformation.AddField("bQCastCount", BossValues.QAbilityCasts.ToString());
        gameInformation.AddField("bQCastHits", BossValues.QAbilityHits.ToString());
        gameInformation.AddField("bWAbility", BossValues.WAbilityName.ToString());
        gameInformation.AddField("bWCastCount", BossValues.WAbilityCasts.ToString());
        gameInformation.AddField("bWCastHits", BossValues.WAbilityHits.ToString());
        gameInformation.AddField("bEAbility", BossValues.EAbilityName.ToString());
        gameInformation.AddField("bECastCount", BossValues.EAbilityCasts.ToString());
        gameInformation.AddField("bECastHits", BossValues.EAbilityHits.ToString());
        gameInformation.AddField("bDamageTaken", BossValues.DamageTaken.ToString());
        gameInformation.AddField("bDamageDealt", BossValues.DamageDealt.ToString());
        gameInformation.AddField("bSpeed", BossValues.Speed.ToString());
        gameInformation.AddField("bArmor", BossValues.Armor.ToString());
        //  Grab Game statistics and serialize it
        gameInformation.AddField("trialDuration", GameData.GameDuration.ToString());
        gameInformation.AddField("scenarioRating", GameData.GameRating.ToString());

        // set up api location url and data
        WWW www = new WWW(URL,gameInformation);
        StartCoroutine(PostData(www));

    }

    IEnumerator PostData(WWW www)
    {
        yield return www;
        if (www.error != null)
        {
            Debug.Log("Data Submitted");
        }else
        {
            Debug.Log(www.error);
        }
    }
}
