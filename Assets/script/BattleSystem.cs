using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public enum BattleState { START,PLAYERTURN,ENEMYTURN,WON,LOST,SURREND}

public class BattleSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab_whiteGirl;
    public GameObject enemyPrefab_purpleguy;
    public GameObject enemyPrefab_berserker;
    public GameObject enemyPrefab_oldman;
    public GameObject enemyPrefab_yamada;
    public GameObject enemyPrefab_activegirl;
    public GameObject itemPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public Text dialogueText;
    public Text dialogueTextItem;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    Unit playerUnit;
    Unit enemyUnit;
    ItemUnit itemUnit;

    int maxHP_save, damage_save;


    public LevelMove_Ref sceneChanger;
    public int sceneChange;

    public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle() 
    {
        EnemyData enemyData = SaveSystem.LoadEnemy();
        if (enemyData.whoToBattle == 1)
        {
            GameObject whiteGirlGO = Instantiate(enemyPrefab_whiteGirl, enemyBattleStation);
            enemyUnit = whiteGirlGO.GetComponent<Unit>();
            //FindObjectOfType<AudioManager>().audio_play("Battle Normal");
        }
        else if (enemyData.whoToBattle == 2)
        {
            GameObject purpleGuyGO = Instantiate(enemyPrefab_purpleguy, enemyBattleStation);
            enemyUnit = purpleGuyGO.GetComponent<Unit>();
            //FindObjectOfType<AudioManager>().audio_play("Battle Normal");
        }
        else if(enemyData.whoToBattle == 3)
        {
            GameObject BerserkerGO = Instantiate(enemyPrefab_berserker, enemyBattleStation);
            enemyUnit = BerserkerGO.GetComponent<Unit>();
            //FindObjectOfType<AudioManager>().audio_play("Battle BBBoss");
        }
        else if (enemyData.whoToBattle == 4)
        {
            GameObject oldmanGO = Instantiate(enemyPrefab_oldman, enemyBattleStation);
            enemyUnit = oldmanGO.GetComponent<Unit>();
            //FindObjectOfType<AudioManager>().audio_play("Battle Gym");
        }
        else if (enemyData.whoToBattle == 5)
        {
            GameObject yamadaGO = Instantiate(enemyPrefab_yamada, enemyBattleStation);
            enemyUnit = yamadaGO.GetComponent<Unit>();
            //FindObjectOfType<AudioManager>().audio_play("Battle Boss");
        }
        else if (enemyData.whoToBattle == 6)
        {
            GameObject activegirlGO = Instantiate(enemyPrefab_activegirl, enemyBattleStation);
            enemyUnit = activegirlGO.GetComponent<Unit>();
            //FindObjectOfType<AudioManager>().audio_play("Battle Boss");
        }


        PlayerData currentData = SaveSystem.LoadPlayer();

        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject itemGO = Instantiate(itemPrefab);
        itemUnit = itemGO.GetComponent<ItemUnit>();

        dialogueText.text = "A wild " +  enemyUnit.unitName+ " approaches...";

        //setup status
        playerUnit.unitName = currentData.unitName;
        playerUnit.unitLevel = currentData.unitLevel;
        playerUnit.maxHP = currentData.maxHP;
        maxHP_save = currentData.maxHP;
        playerUnit.currentHP = currentData.currentHP;
        playerUnit.exp = currentData.exp;
        playerUnit.expToLvlUp = currentData.expToLvlUp;
        playerUnit.damage = currentData.damage;
        damage_save = currentData.damage;
        itemUnit.money = currentData.money;
        itemUnit.gun = currentData.gun;
        itemUnit.knife = currentData.knife;
        itemUnit.ATgauge = currentData.ATgauge;

        itemUnit.fullHeal = currentData.fullHeal;
        itemUnit.ATbooster = currentData.ATbooster;
        itemUnit.hamburger = currentData.hamburger;
        itemUnit.cola = currentData.hamburger;
        itemUnit.fries = currentData.fries;


        //player equipment setup
        if (itemUnit.gun == true) {
            Debug.Log("Gun purchased");
            playerUnit.weaponPurchase(playerUnit.damage*2); 
        }
        if (itemUnit.knife == true)
        {
            Debug.Log("Knife purchased");
            playerUnit.weaponPurchase(playerUnit.damage*3);
        }
        if (itemUnit.ATgauge == true)
        {
            Debug.Log("AT Gauge purchased");
            playerUnit.atGaugePurchase();
        }

        playerHUD.SetupHUD(playerUnit);
        enemyHUD.SetupHUD(enemyUnit);

        yield return new WaitForSeconds(3f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack() 
    {
        dialogueText.text = playerUnit.unitName + " attacks!";
        //damage enemy
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        state = BattleState.ENEMYTURN;

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            //End the battle 
            state = BattleState.WON;
            EndBattle();
        }
        else 
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

        }
    }

    IEnumerator PlayerHeal(int healAmount) 
    {
        playerUnit.Heal(healAmount);
        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "You feel renewed strength~";
        state = BattleState.ENEMYTURN;

        yield return new WaitForSeconds(1f);


        StartCoroutine(EnemyTurn());


    }
    IEnumerator PlayerBuff(int dmgUp) {

        playerUnit.weaponPurchase(dmgUp);
        dialogueText.text = "You feel your power have increased";
        state = BattleState.ENEMYTURN;

        yield return new WaitForSeconds(1f);
        StartCoroutine(EnemyTurn());
    }

    
    IEnumerator EnemyTurn() 
    {
        dialogueText.text = enemyUnit.unitName + " attacks!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            //End the battle 
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();

        }
    }

    void EndBattle() 
    {
        playerUnit.damageSet(damage_save);
        playerUnit.HpSet(maxHP_save);

        if (state == BattleState.WON)
        {
            int EXPadd=0;
            int moneyadd = 0;
            EnemyData enemy = new EnemyData();
            if (enemyUnit.unitName == "whiteGirl")
            {
                enemy.whiteGirl = false;
                EXPadd = 10;
                moneyadd = 250;
            }
            else if (enemyUnit.unitName == "purpleguy")
            {
                enemy.purpleguy = false;
                EXPadd = 20;
                moneyadd = 500;
            }
            else if (enemyUnit.unitName == "Berseker")
            {
                enemy.berserker = false;
                EXPadd = 1000;
                moneyadd = 10000;
            }
            else if (enemyUnit.unitName == "Oldman")
            {
                enemy.oldman = false;
                EXPadd = 100;
                moneyadd = 7500;
            }
            else if (enemyUnit.unitName == "Yamada")
            {
                enemy.yamada = false;
                EXPadd = 150;
                moneyadd = 5000;
            }
            else if (enemyUnit.unitName == "ActiveGirl") 
            {
                enemy.activegirl = false;
                EXPadd = 200;
                moneyadd = 5000;
            }
            playerUnit.exp = playerUnit.exp + EXPadd;
            itemUnit.money = itemUnit.money + moneyadd;
            dialogueText.text = "You won, you get $"+moneyadd;
            while (playerUnit.exp >= playerUnit.expToLvlUp) 
            {
                
                dialogueText.text = "Level UP!!!!";
                playerHUD.SetEXP(playerUnit.expToLvlUp);
                
                playerUnit.unitLevel++;
                playerUnit.damage += 3 * playerUnit.unitLevel;
                playerUnit.maxHP += 10 * playerUnit.unitLevel;

                playerUnit.exp = playerUnit.exp - playerUnit.expToLvlUp;
                if (playerUnit.exp < 0)
                    playerUnit.exp = 0;
                
                playerUnit.expToLvlUp += 10;
                playerHUD.SetLvExpmax(playerUnit);
                LoadingLvlUp();

            }

            playerHUD.SetEXP(playerUnit.exp);

            dialogueText.text = "You won, you get $" + moneyadd;

            SaveSystem.SavePlayer(playerUnit, itemUnit);
            SaveSystem.SaveEnemy(enemy);


            sceneChanger.transition.SetTrigger("start");


            sceneChanger.LoadLevel(sceneChange);



        }
        else if (state == BattleState.LOST)
        {
            int moneylost = UnityEngine.Random.Range(100, 1000);
            dialogueText.text = "You lost , $"+moneylost+" has been stolen";
            playerUnit.currentHP = 50;

            if (itemUnit.money > moneylost)
            {
                itemUnit.money -= moneylost;
            }
            else 
            {
                itemUnit.money = 0;
            }
           
            SaveSystem.SavePlayer(playerUnit, itemUnit);
            
            EnemyData enemy = new EnemyData();
            if (enemyUnit.unitName == "whiteGirl")
            {
                enemy.whiteGirl = false;
            }
            else if (enemyUnit.unitName == "purpleguy")
            {
                enemy.purpleguy = false;
            }
            else if (enemyUnit.unitName == "Berseker")
            {
                enemy.berserker = false;
 
            }
            else if (enemyUnit.unitName == "Oldman")
            {
                enemy.oldman = false;
            }
            else if (enemyUnit.unitName == "Yamada")
            {
                enemy.yamada = false;
            }
            else if (enemyUnit.unitName == "ActiveGirl")
            {
                enemy.activegirl = false;
            }
            SaveSystem.SaveEnemy(enemy);


            sceneChanger.transition.SetTrigger("start");


            sceneChanger.LoadLevel(7);

        }
        else if (state == BattleState.SURREND) 
        {
            int moneylost = UnityEngine.Random.Range(100, 200);
            dialogueText.text = "Your run away, $"+ moneylost+" has been paid";
            if (itemUnit.money > moneylost)
            {
                itemUnit.money -= moneylost;
            }
            else
            {
                itemUnit.money = 0;
            }
            SaveSystem.SavePlayer(playerUnit, itemUnit);

            EnemyData enemy = new EnemyData();
            if (enemyUnit.unitName == "whiteGirl")
            {
                enemy.whiteGirl = false;
            }
            else if (enemyUnit.unitName == "purpleguy")
            {
                enemy.purpleguy = false;
            }
            else if (enemyUnit.unitName == "Berseker")
            {
                enemy.berserker = false;

            }
            else if (enemyUnit.unitName == "Oldman")
            {
                enemy.oldman = false;
            }
            else if (enemyUnit.unitName == "Yamada")
            {
                enemy.yamada = false;
            }
            else if (enemyUnit.unitName == "ActiveGirl")
            {
                enemy.activegirl = false;
            }
            SaveSystem.SaveEnemy(enemy);


            sceneChanger.transition.SetTrigger("start");


            sceneChanger.LoadLevel(sceneChange);


        }
    }
    IEnumerator LoadingLvlUp()
    {
        yield return new WaitForSeconds(2f);
    }
    void PlayerTurn() 
    {
        dialogueText.text = "Choose an action: ";
    
    }

    public void OnAttackButton() 
    {
        if (state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerHeal(20));
    }

    public void OnRunButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        state = BattleState.SURREND;
        EndBattle();
    }


    //itemButtonSet
    public void OnColaButton() {
        if (state != BattleState.PLAYERTURN) 
        {
            return;    
        }
        if (itemUnit.cola == 0)
        {
            dialogueText.text = "No cola obtain";
            //dialogueTextItem.text = "No cola obtain";
            return;
        }
        itemUnit.buyOrUseCola(-1);
        StartCoroutine(PlayerHeal(20));
    }
    public void OnFriesButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        if (itemUnit.fries == 0)
        {
            dialogueText.text = "No fries obtain";
            //dialogueTextItem.text = "No fries obtain";
            return;
        }
        itemUnit.buyOrUseFries(-1);
        StartCoroutine(PlayerHeal(50));
    }
    public void OnHamburgerButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        if (itemUnit.hamburger == 0)
        {
            dialogueText.text = "No hamburger obtain";
            //dialogueTextItem.text = "No hamburger obtain";
            return;
        }
        itemUnit.buyOrUseHamburger(-1);
        
        StartCoroutine(PlayerHeal(100));
    }
    public void OnAtBoosterButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        if (itemUnit.ATbooster == 0)
        {
            dialogueText.text = "No ATbooster obtain";
            //dialogueTextItem.text = "No ATbooster obtain";
            return;
        }
        itemUnit.buyOrUseATbooster(-1);
        StartCoroutine(PlayerBuff(playerUnit.damage));
    }
    public void OnFullHealButton() 
    {
        if (state != BattleState.PLAYERTURN) 
        {
            return;
        }
        if (itemUnit.fullHeal == 0)
        {
            dialogueText.text = "No FullHeal obtain";
            //dialogueTextItem.text = "No FullHeal obtain";
            return;
        }
        itemUnit.buyOrUseFullHeal(-1);
        StartCoroutine(PlayerHeal(100000));

    }



}
