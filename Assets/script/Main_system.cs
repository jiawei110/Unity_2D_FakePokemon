using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.Timers;

public class Main_system : MonoBehaviour
{
    public GameObject enemyPrefab_whiteGirl;
    public GameObject enemyPrefab_purpleguy;
    public GameObject enemyPrefab_berserker;
    public GameObject enemyPrefab_yamada;
    public GameObject enemyPrefab_oldman;
    public GameObject enemyPrefab_activegirl;
    public float timer_w  = 5f;
    public float timer_p = 5f;
    public float timer_b = 5f;
    public float timer_y = 5f;
    public float timer_o = 5f;
    public float timer_a = 5f;
    bool stopUpdate_whiteGirl = false;
    bool stopUpdate_purpleguy = false;
    bool stopUpdate_berserker = false;
    bool stopUpdate_yamada = false;
    bool stopUpdate_oldman = false;
    bool stopUpdate_activegirl = false;


    Unit enemyUnit;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().StopAudio();
        FindObjectOfType<AudioManager>().audio_play("BGM");


        EnemyData enemyShow = SaveSystem.LoadEnemy();
        if (enemyShow.whiteGirl)
        {
            Debug.Log("Run whiteGirl");
            GameObject whiteGirl = Instantiate(enemyPrefab_whiteGirl);
            enemyUnit = whiteGirl.GetComponent<Unit>();
            stopUpdate_whiteGirl = true;
        }
        if (enemyShow.purpleguy)
        {
            Debug.Log("Run purpleguy");
            GameObject purpleguy = Instantiate(enemyPrefab_purpleguy);
            enemyUnit = purpleguy.GetComponent<Unit>();
            stopUpdate_purpleguy = true;
        }
        if (enemyShow.berserker)
        {
            Debug.Log("Run berserker");
            GameObject berserker = Instantiate(enemyPrefab_berserker);
            enemyUnit = berserker.GetComponent<Unit>();
            stopUpdate_berserker = true;
        }
        if (enemyShow.yamada)
        {
            Debug.Log("Run yamada");
            GameObject yamada = Instantiate(enemyPrefab_yamada);
            enemyUnit = yamada.GetComponent<Unit>();
            stopUpdate_yamada = true;
        }
        if (enemyShow.oldman)
        {
            Debug.Log("Run oldman");
            GameObject oldman = Instantiate(enemyPrefab_oldman);
            enemyUnit = oldman.GetComponent<Unit>();
            stopUpdate_oldman = true;
        }
        if (enemyShow.activegirl)
        {
            Debug.Log("Run activegirl");
            GameObject activegirl = Instantiate(enemyPrefab_activegirl);
            enemyUnit = activegirl.GetComponent<Unit>();
            stopUpdate_activegirl = true;
        }

    }
 
    /*
    private void TimerUp(object sender, System.Timers.ElapsedEventArgs e) 
    {
        Debug.Log("Save");
        if (!enemyShow.whiteGirl) 
        {
            Debug.Log("Run if");
            GameObject whiteGirl = Instantiate(enemyPrefab1);
            enemyUnit = whiteGirl.GetComponent<Unit>();
            atimer.Enabled = false;
            enemyShow.whiteGirl = true;
        }
    }


    */
    void Update() 
    {
        if (!stopUpdate_whiteGirl && Time.timeSinceLevelLoad > timer_w) 
        {
            EnemyData enemyShow = SaveSystem.LoadEnemy();
            Debug.Log("Run whiteGirl appeared");
            GameObject whiteGirl = Instantiate(enemyPrefab_whiteGirl);
            enemyUnit = whiteGirl.GetComponent<Unit>();
            enemyShow.whiteGirl = true;
            StartCoroutine(ChangeState("whiteGirl"));
            stopUpdate_whiteGirl = true;

        }
        if (!stopUpdate_purpleguy && Time.timeSinceLevelLoad > timer_p)
        {
            EnemyData enemyShow = SaveSystem.LoadEnemy();
            Debug.Log("Run purpleguy appeared");
            GameObject purpleguy = Instantiate(enemyPrefab_purpleguy);
            enemyUnit = purpleguy.GetComponent<Unit>();
            stopUpdate_purpleguy = true;
            StartCoroutine(ChangeState("purpleguy"));
            stopUpdate_purpleguy = true;

        }
        if (!stopUpdate_berserker && Time.timeSinceLevelLoad > timer_b)
        {
            EnemyData enemyShow = SaveSystem.LoadEnemy();
            Debug.Log("Run berserker appeared");
            GameObject berserker = Instantiate(enemyPrefab_berserker);
            enemyUnit = berserker.GetComponent<Unit>();
            stopUpdate_berserker = true;
            StartCoroutine(ChangeState("berserker"));
            stopUpdate_berserker = true;

        }
        if (!stopUpdate_yamada && Time.timeSinceLevelLoad > timer_w)
        {
            EnemyData enemyShow = SaveSystem.LoadEnemy();
            Debug.Log("Run yamada appeared");
            GameObject yamada = Instantiate(enemyPrefab_yamada);
            enemyUnit = yamada.GetComponent<Unit>();
            enemyShow.yamada = true;
            StartCoroutine(ChangeState("yamada"));
            stopUpdate_yamada = true;

        }
        if (!stopUpdate_oldman && Time.timeSinceLevelLoad > timer_p)
        {
            EnemyData enemyShow = SaveSystem.LoadEnemy();
            Debug.Log("Run oldman appeared");
            GameObject oldman = Instantiate(enemyPrefab_oldman);
            enemyUnit = oldman.GetComponent<Unit>();
            stopUpdate_oldman = true;
            StartCoroutine(ChangeState("oldman"));
            stopUpdate_oldman = true;

        }
        if (!stopUpdate_activegirl && Time.timeSinceLevelLoad > timer_b)
        {
            EnemyData enemyShow = SaveSystem.LoadEnemy();
            Debug.Log("Run activegirl appeared");
            GameObject activegirl = Instantiate(enemyPrefab_activegirl);
            enemyUnit = activegirl.GetComponent<Unit>();
            stopUpdate_activegirl = true;
            StartCoroutine(ChangeState("activegirl"));
            stopUpdate_activegirl = true;

        }



    }
    IEnumerator ChangeState(string x)
    {
        EnemyData show = new EnemyData();

        if (x == "whiteGirl")
        {
            show.whiteGirl = true;
        }
        if (x == "purpleguy")
        {
            show.purpleguy = true;
        }
        if (x == "berserker")
        {
            show.berserker = true;
        }
        if (x == "yamada")
        {
            show.yamada = true;
        }
        if (x == "oldman")
        {
            show.oldman = true;
        }
        if (x == "activegirl")
        {
            show.activegirl = true;
        }
        SaveSystem.SaveEnemy(show); 

        yield return new WaitForSeconds(0.1f);
    }


}