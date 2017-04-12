using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using UnityEngine.UI;
using UnityEngine;

public class GameMonitor : MonoBehaviour {

    public Image PlayerHealthBar;
    public Image BossHealthBar;
    private Stopwatch gameDuration;
    //private GameMonitor RestartDialoug;

	// Use this for initialization
	void Start () {
        gameDuration = new Stopwatch();
        gameDuration.Start();
	}
	
	// Update is called once per frame
	void Update () {
        monitorHealth();
	}

    void monitorHealth()
    {
        //  Player Healthbar Scaling.
        PlayerHealthBar.rectTransform.localScale = new Vector3( PlayerValues.Health / PlayerValues.MaxHealth,
                                                                PlayerHealthBar.rectTransform.localScale.y,
                                                                PlayerHealthBar.rectTransform.localScale.z);
        //  Boss Healthbar Scaling.
        BossHealthBar.rectTransform.localScale = new Vector3( BossValues.Health / BossValues.MaxHealth,
                                                              BossHealthBar.rectTransform.localScale.y,
                                                              BossHealthBar.rectTransform.localScale.z);

        // If player or boss health reach zero, then bring up dialoug to restart.
        if (PlayerValues.Health <= 0)
        {
            gameDuration.Stop();
            GameData.GameDuration = gameDuration.Elapsed.Seconds;
            gameDuration.Reset();
            LoadScene("Defeated");
        }
        else if (BossValues.Health <= 0)
        {
            gameDuration.Stop();
            GameData.GameDuration = gameDuration.Elapsed.Seconds;
            gameDuration.Reset();
            LoadScene("Victory");
        }

    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
