using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCtrl : MonoBehaviour {

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
        //  Grab player data and serialize it

        //  Grab boss data and serialize it

        //  Grab Game statistics and serialize it

        //  Push to API
    }

}
