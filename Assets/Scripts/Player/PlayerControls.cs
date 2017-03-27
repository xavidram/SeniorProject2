using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    private GameObject Projectile;
    //  ability cooldown stopwatch timers
    private Stopwatch qStopwatch = new Stopwatch();
    private Stopwatch wStopwatch = new Stopwatch();
    private Stopwatch eStopwatch = new Stopwatch();
    private Stopwatch rStopwatch = new Stopwatch();

    //  Ability Cooldown Times
    private float qCoolDownTime = 2f;
    private float wCoolDownTime = 5f;
    private float eCoolDownTime = 5f;
    private float rCoolDownTime = 10f;

    //  Ability Casted Bools
    private bool qAbilityCasted;
    private bool wAbilityCasted;
    private bool eAbilityCasted;
    private bool rAbilityCasted;

	// Use this for initialization
	void Start () {
        Projectile = GameObject.Find("Projectile");
        resetAbilityBooleans(); //  Lets first reset abilities when game starts.

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(qAbilityCasted == false){
                CastQAbility();
                qStopwatch.Start();
                qAbilityCasted = true;
            }else{
                if(qStopwatch.Elapsed.Seconds >= qCoolDownTime){
                    qStopwatch.Stop();
                    qStopwatch.Reset();
                    qAbilityCasted = false;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if(wAbilityCasted == false){
                CastWAbility();
                wStopwatch.Start();
                wAbilityCasted = true;
            }else{
                if(wStopwatch.Elapsed.Seconds >= wCoolDownTime){
                    wStopwatch.Stop();
                    wStopwatch.Reset();
                    wAbilityCasted = false;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(eAbilityCasted == false){
                CastQAbility();
                eStopwatch.Start();
                eAbilityCasted = true;
            }else{
                if(eStopwatch.Elapsed.Seconds >= eCoolDownTime){
                    eStopwatch.Stop();
                    eStopwatch.Reset();
                    eAbilityCasted = false;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(rAbilityCasted == false){
                CastQAbility();
                rStopwatch.Start();
                rAbilityCasted = true;
            }else{
                if(rStopwatch.Elapsed.Seconds >= rCoolDownTime){
                    rStopwatch.Stop();
                    rStopwatch.Reset();
                    rAbilityCasted = false;
                }
            }
        }
    }

    public void CastQAbility()
    {
        UnityEngine.Debug.Log("Csting Q Ability");
        UnityEngine.Debug.Log(BossValues.Speed.ToString());
        GameObject Clone = Instantiate<GameObject>(Projectile);
        Clone.transform.position = this.transform.position;
        Clone.GetComponent<Renderer>().enabled = true;
        Clone.SetActive(true);
    }
    public void CastWAbility(){}
    public void CastEAbility(){}
    public void CastRAbility(){}

    private void resetAbilityBooleans(){
        qAbilityCasted = false;
        wAbilityCasted = false;
        eAbilityCasted = false;
        rAbilityCasted = false;
    }

}
