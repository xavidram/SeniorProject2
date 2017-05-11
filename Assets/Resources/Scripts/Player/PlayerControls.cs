using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{

    private enum QAbilities : int
    {
        FireBall = 0,
        IceShard = 1,
        FireSword = 2,
        IceSword = 3
    }

    private enum WAbilities : int
    {
        Chainmain = 0,
        GoldenApple = 1,
        SpellShield = 2,
        Steriods = 3
    }

    private enum EAbilities : int
    {
        //Blink = 0,
        Barrier = 0
    }

    private enum RAbilities : int
    {
        Firecannon = 0,
        Iceblast = 1
    }

    private GameObject Projectile;
    private ProjectileBehaviour PBehavior;

    //  ability cooldown stopwatch timers
    private Stopwatch qStopwatch = new Stopwatch();
    private Stopwatch wStopwatch = new Stopwatch();
    private Stopwatch eStopwatch = new Stopwatch();
    private Stopwatch rStopwatch = new Stopwatch();

    //  Ability Cooldown Times
    private float qCoolDownTime;
    private float wCoolDownTime;
    private float eCoolDownTime;
    private float rCoolDownTime;
    private float qCurrentCooldown;
    private float wCurrentCooldown;
    private float eCurrentCooldown;
    private float rCurrentCooldown;

    //  Ability Casted Bools
    private bool qAbilityCasted;
    private bool wAbilityCasted;
    private bool eAbilityCasted;
    private bool rAbilityCasted;

    private int QAbilityRandom;
    private int EAbilityRandom;
    private int WAbilityRandom;
    private int RAbilityRandom;

    // ability buttons
    public Image qImage;
    public Image wImage;
    public Image eImage;
    public Image rImage;

    // Use this for initialization
    void Start()
    {
        //Cooldowns
        qCoolDownTime = Random.Range(0, PlayerValues.QCoolDownTime);
        wCoolDownTime = Random.Range(0, PlayerValues.WCoolDownTime);
        eCoolDownTime = Random.Range(0, PlayerValues.ECoolDownTime);
        rCoolDownTime = Random.Range(0, PlayerValues.RCoolDownTime);
        qCurrentCooldown = wCurrentCooldown = eCurrentCooldown = rCurrentCooldown = 0;

        Projectile = GameObject.Find("Projectile");
        resetAbilityBooleans(); //  Lets first reset abilities when game starts.
        QAbilityRandom = Random.Range(0, System.Enum.GetValues(typeof(QAbilities)).Length);
        //SetQAbility();
        WAbilityRandom = Random.Range(0, System.Enum.GetValues(typeof(WAbilities)).Length);
        SetWAbility();
        EAbilityRandom = Random.Range(0, System.Enum.GetValues(typeof(EAbilities)).Length);
        //SetEAbility();
        RAbilityRandom = Random.Range(0, System.Enum.GetValues(typeof(RAbilities)).Length);

    }

    // Update is called once per frame
    void Update()
    {
        // Monitor cooldowns and update
        if (qStopwatch.Elapsed.Seconds < qCoolDownTime && qAbilityCasted == true)
        {
            qCurrentCooldown += Time.deltaTime;
            qImage.fillAmount = qCurrentCooldown / qCoolDownTime;
        }
        if (wStopwatch.Elapsed.Seconds < wCoolDownTime && wAbilityCasted == true)
        {
            wCurrentCooldown += Time.deltaTime;
            wImage.fillAmount = wCurrentCooldown / wCoolDownTime;
        }
        if (eStopwatch.Elapsed.Seconds < eCoolDownTime  && eAbilityCasted == true)
        {
            eCurrentCooldown += Time.deltaTime;
            eImage.fillAmount = eCurrentCooldown / eCoolDownTime;
        }
        if (rStopwatch.Elapsed.Seconds < rCoolDownTime && rAbilityCasted == true)
        {
            rCurrentCooldown += Time.deltaTime;
            rImage.fillAmount = rCurrentCooldown / rCoolDownTime;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (qAbilityCasted == false)
            {
                CastQAbility();
                qStopwatch.Start();
                qAbilityCasted = true;
            }
            else
            {
                if (qStopwatch.Elapsed.Seconds >= qCoolDownTime)
                {
                    qStopwatch.Stop();
                    qStopwatch.Reset();
                    qAbilityCasted = false;
                    qCurrentCooldown = 0;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (wAbilityCasted == false)
            {
                CastWAbility();
                wStopwatch.Start();
                wAbilityCasted = true;
            }
            else
            {
                if (wStopwatch.Elapsed.Seconds >= wCoolDownTime)
                {
                    wStopwatch.Stop();
                    wStopwatch.Reset();
                    wAbilityCasted = false;
                    wCurrentCooldown = 0;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (eAbilityCasted == false)
            {
                CastEAbility();
                eStopwatch.Start();
                eAbilityCasted = true;
            }
            else
            {
                if (eStopwatch.Elapsed.Seconds >= eCoolDownTime)
                {
                    eStopwatch.Stop();
                    eStopwatch.Reset();
                    eAbilityCasted = false;
                    eCurrentCooldown = 0;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (rAbilityCasted == false)
            {
                CastRAbility();
                rStopwatch.Start();
                rAbilityCasted = true;
            }
            else
            {
                if (rStopwatch.Elapsed.Seconds >= rCoolDownTime)
                {
                    rStopwatch.Stop();
                    rStopwatch.Reset();
                    rAbilityCasted = false;
                    rCurrentCooldown = 0;
                }
            }
        }
    }

    public void CastQAbility()
    {
        PlayerValues.QAbilityCasts += 1;
        if(QAbilityRandom == (int)QAbilities.FireBall){
            GameObject Fireball = GameObject.Find("fireball_projectile");
            Fireball.gameObject.GetComponent<FireBall>().UseAbility(this.transform.position);
        }
        else if(QAbilityRandom == (int)QAbilities.IceShard){
            GameObject IceShard = GameObject.Find("iceshard_projectile");
            IceShard.gameObject.GetComponent<IceShard>().UseAbility(this.transform.position);
        }
        else if(QAbilityRandom == (int)QAbilities.FireSword) {
            GameObject FireSword = GameObject.Find("firesword_meele");
            FireSword.gameObject.GetComponent<FireSword>().UseAbility(this.transform.position);
        }
        else if (QAbilityRandom == (int)QAbilities.IceSword){
            GameObject IceSword = GameObject.Find("icesword_meele");
            IceSword.gameObject.GetComponent<IceSword>().UseAbility(this.transform.position);
        }
        
    }
    public void CastWAbility()
    {
        PlayerValues.WAbilityCasts += 1;
        UnityEngine.Debug.Log(WAbilityRandom.ToString());
        if (WAbilityRandom == (int)WAbilities.Chainmain)
            this.gameObject.GetComponent<Chainmail>();
        else if (WAbilityRandom == (int)WAbilities.GoldenApple)
            this.gameObject.AddComponent<GoldenApple>();
        else if (WAbilityRandom == (int)WAbilities.SpellShield)
            this.gameObject.AddComponent<SpellShield>();
        else if (WAbilityRandom == (int)WAbilities.Steriods)
            this.gameObject.AddComponent<Steroids>();
    }
    public void CastEAbility()
    {
        PlayerValues.EAbilityCasts += 1;
        UnityEngine.Debug.Log(EAbilityRandom.ToString());
        /* Disabling until fixed
        if (EAbilityRandom == (int)EAbilities.Blink)
        {
            this.gameObject.AddComponent<Blink>().UseAbility();
        }
        
        else */if (EAbilityRandom == (int)EAbilities.Barrier)
        {
            GameObject Rock = GameObject.Find("Rock");
            Rock.gameObject.GetComponent<Barrier>().UseAbility(this.transform.position);
            if (PlayerValues.EAbilityName == " ")
                PlayerValues.EAbilityName = "Barrier";
        }
        
    }
    public void CastRAbility() {
        PlayerValues.RAbilityCasts += 1;
        if (RAbilityRandom == (int)RAbilities.Firecannon)
        {
            GameObject FireCannon = GameObject.Find("firecannon");
            FireCannon.gameObject.GetComponent<FireCannon>().UseAbility(this.transform.position);
            if (PlayerValues.RAbilityName == " ")
                PlayerValues.RAbilityName = "FireCannon";
        }
        else if (RAbilityRandom == (int)RAbilities.Iceblast)
        {
            GameObject IceBlast = GameObject.Find("iceblast");
            IceBlast.gameObject.GetComponent<IceBlast>().UseAbility(this.transform.position);
            if (PlayerValues.RAbilityName == " ")
                PlayerValues.RAbilityName = "IceBlast";
        }
    }

    private void resetAbilityBooleans()
    {
        qAbilityCasted = false;
        wAbilityCasted = false;
        eAbilityCasted = false;
        rAbilityCasted = false;
    }

    public void SetWAbility()
    {
        UnityEngine.Debug.Log(WAbilityRandom.ToString());
        if (WAbilityRandom == (int)WAbilities.Chainmain)
        {
            this.gameObject.AddComponent<Chainmail>();
            PlayerValues.WAbilityName = "Chainmail";
        }
        else if (WAbilityRandom == (int)WAbilities.GoldenApple)
        {
            this.gameObject.AddComponent<GoldenApple>();
            PlayerValues.WAbilityName = "GoldenApple";
        }
        else if (WAbilityRandom == (int)WAbilities.SpellShield)
        {
            this.gameObject.AddComponent<SpellShield>();
            PlayerValues.WAbilityName = "SpellShield";
        }
        else if (WAbilityRandom == (int)WAbilities.Steriods)
        {
            this.gameObject.AddComponent<Steroids>();
            PlayerValues.WAbilityName = "SpellShield";
        }
    }
}
