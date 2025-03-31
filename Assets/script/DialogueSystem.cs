using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum State {ORDERING,PAYING,WALKING,FACING}

public class DialogueSystem : MonoBehaviour
{
    public string payToWho;

    public Text currentMoneyshow;
    public Text totalamountshow;

    public Text friesamount;
    public Text Hamburgeramount;
    public Text Colaamount;
    private int friesBuy = 0;
    private int colaBuy = 0;
    private int hamburgerBuy = 0;

    public Text GunEnable;
    public Text KnifeEnable;
    public Text ATgaugeEnable;
    public Button gun;
    public Button knife;
    public Button ATgauge;
    private bool gunBuy = false;
    private bool knifeBuy = false;
    private bool ATgaugeBuy = false;

    public Text ATbooster_amount;
    public Text FullHeal_amount;
    private int ATboosterBuy = 0;
    private int FullHealBuy = 0;





    public Unit playerUnit;
    public ItemUnit itemUnit;
    private int total = 0;

    public State state;

    void Start() 
    {
        FindObjectOfType<AudioManager>().StopAudio();
    }
    public void onFriesButton()
    {
        if (state == State.PAYING) 
        {
            return;
        }
        friesBuy++;
        friesamount.text = friesBuy.ToString();
        total += 45;
        currentMoneyshow.text = "Your wallet: $" + itemUnit.money ;
        totalamountshow.text = "Total amount: $" + total.ToString();
    }
    public void onHamburgerButton()
    {
        if (state == State.PAYING)
        {
            return;
        }
        hamburgerBuy++;
        Hamburgeramount.text = hamburgerBuy.ToString();
        total += 75;
        currentMoneyshow.text = "Your wallet: $" + itemUnit.money;
        totalamountshow.text = "Total amount: $" + total.ToString();
    }
    public void onColaButton()
    {
        if (state == State.PAYING)
        {
            return;
        }
        colaBuy++;
        Colaamount.text = colaBuy.ToString();
        total += 25;
        currentMoneyshow.text = "Your wallet: $" + itemUnit.money;
        totalamountshow.text = "Total amount: $" + total.ToString();
    }


    /// <summary>
    /// shop_weapon scene
    /// </summary>
    public void onShow_weaponset() 
    {
        if (itemUnit.gun == true) 
        {
            Debug.Log("Gun obtain");
            gunBuy = true;
            GunEnable.text = "purchased";
            gun.interactable = false;
        }
        if (itemUnit.knife == true)
        {
            Debug.Log("knife obtain");
            knifeBuy = true;
            KnifeEnable.text = "purchased";
            knife.interactable = false;
        }
        if (itemUnit.ATgauge == true)
        {
            Debug.Log("ATgauge obtain");
            ATgaugeBuy = true;
            ATgaugeEnable.text = "purchased";
            ATgauge.interactable = false;
        }
    }
    public void onGunButton() 
    {
        if (state == State.ORDERING && !itemUnit.gun && !gunBuy)
        {
            gunBuy = true;
            GunEnable.text = "Selected";
            total += 250;
            currentMoneyshow.text = "Your wallet: $" + itemUnit.money;
            totalamountshow.text = "Total amount: $" + total.ToString();

            return;
        }
        else if (state == State.ORDERING && !itemUnit.gun && gunBuy) 
        {
            gunBuy = false;
            GunEnable.text = "NO";
            total -= 250;
            currentMoneyshow.text = "Your wallet: $" + itemUnit.money;
            totalamountshow.text = "Total amount: $" + total.ToString();
        }
        
    }

    public void onKnifeButton()
    {
        if (state == State.ORDERING && !itemUnit.knife && !knifeBuy)
        {
            knifeBuy = true;
            KnifeEnable.text = "Selected";
            total += 500;
            currentMoneyshow.text = "Your wallet: $" + itemUnit.money;
            totalamountshow.text = "Total amount: $" + total.ToString();

            return;
        }
        else if (state == State.ORDERING && !itemUnit.knife && knifeBuy)
        {
            knifeBuy = false;
            KnifeEnable.text = "NO";
            total -= 500;
            currentMoneyshow.text = "Your wallet: $" + itemUnit.money;
            totalamountshow.text = "Total amount: $" + total.ToString();
        }

    }

    public void onATGaugeButton()
    {
        if (state == State.ORDERING && !itemUnit.ATgauge && !ATgaugeBuy)
        {
            ATgaugeBuy = true;
            ATgaugeEnable.text = "Selected";
            total += 1000;
            currentMoneyshow.text = "Your wallet: $" + itemUnit.money;
            totalamountshow.text = "Total amount: $" + total.ToString();

            return;
        }
        else if (state == State.ORDERING && !itemUnit.ATgauge && ATgaugeBuy)
        {
            ATgaugeBuy = false;
            ATgaugeEnable.text = "NO";
            total -= 1000;
            currentMoneyshow.text = "Your wallet: $" + itemUnit.money;
            totalamountshow.text = "Total amount: $" + total.ToString();
        }

    }

    /// <summary>
    /// HealStation
    /// </summary>
    public void onATBoosterButton() 
    {
        if (state == State.PAYING)
        {
            return;
        }
        ATboosterBuy++;
        ATbooster_amount.text = ATboosterBuy.ToString();
        total += 1000;
        currentMoneyshow.text = "Your wallet: $" + itemUnit.money;
        totalamountshow.text = "Total amount: $" + total.ToString();
    }
    public void onFullHealButton() 
    {
        if (state == State.PAYING)
        {
            return;
        }
        FullHealBuy++;
        FullHeal_amount.text = FullHealBuy.ToString();
        total += 1000;
        currentMoneyshow.text = "Your wallet: $" + itemUnit.money;
        totalamountshow.text = "Total amount: $" + total.ToString();
    }
    public void onHealMeNowButton()
    {
        if (state == State.PAYING)
        {
            return;
        }
        if (playerUnit.currentHP == playerUnit.maxHP)
        {
            currentMoneyshow.text = "Nurse: ";
            totalamountshow.text = "You are healthy now";
            return;
        }
        else if (itemUnit.money < 500)
        {
            currentMoneyshow.text = "Nurse: ";
            totalamountshow.text = "I dont think you have enough money....";
        }
        else
        {
            itemUnit.money -= 500;
            playerUnit.currentHP = playerUnit.maxHP;
            currentMoneyshow.text = "Your wallet: $" + itemUnit.money;
            totalamountshow.text = "Your HP have recovered";

        }


    }

    public void onPayButton() 
    {
        StartCoroutine(paying());
        /*
        state = State.PAYING;
        if (itemUnit.money < total)
        {
            totalamountshow.text = "You think you are rich? loser!!!\r\n" + "(You don't have enough money~)";
            yield WaitForSeconds(2);
            onResetButton();
        }
        else 
        {
            itemUnit.money -= total;
            itemUnit.cola += colaBuy;
            itemUnit.hamburger += hamburgerBuy;
            itemUnit.fries += friesBuy;
            totalamountshow.text = "Thank you~ We hope to see you again~";
            currentMoneyshow.text = "Your wallet: $" + itemUnit.money;

        }
        */
    }
    IEnumerator paying() 
    {
        state = State.PAYING;
        if (itemUnit.money < total)
        {
            totalamountshow.text = "You think you are rich? loser!!!\r\n";
            yield return new WaitForSeconds(2);

            if (payToWho.Equals("normalMarket"))
            {
                onResetButton();
            }
            else if (payToWho.Equals("blackMarket"))
            {
                //weaponmarket reset
                state = State.ORDERING;
                total = 0;
                gunBuy = false;
                knifeBuy = false;
                ATgaugeBuy = false;

                GunEnable.text = "NO";
                KnifeEnable.text = "NO";
                ATgaugeEnable.text = "NO";
                onShow_weaponset();

                currentMoneyshow.text = "Your wallet: $" + itemUnit.money;
                totalamountshow.text = "Total amount: $" + total.ToString();

            }
            else if (payToWho.Equals("healStation"))
            {
                onResetButton_healStation();
            }
        }
        else if (itemUnit.money >= total && !payToWho.Equals("blackMarket"))
        {
            //for healStation and normalmarket
            itemUnit.money -= total;

            //when ordering with blackmarket these all will be 0
            itemUnit.cola += colaBuy;
            itemUnit.hamburger += hamburgerBuy;
            itemUnit.fries += friesBuy;

            itemUnit.ATbooster += ATboosterBuy;
            itemUnit.fullHeal += FullHealBuy;

            totalamountshow.text = "Thank you~ We hope to see you again~";
            currentMoneyshow.text = "Your wallet: $" + itemUnit.money;
            yield return new WaitForSeconds(5);
            if (payToWho.Equals("normalMarket"))
                onResetButton();
            else if (payToWho.Equals("healStation"))
                onResetButton_healStation();



        }
        else 
        {
            //for black market
            itemUnit.gun = gunBuy;
            itemUnit.knife = knifeBuy;
            itemUnit.ATgauge = ATgaugeBuy;
            totalamountshow.text = "Thank you~ We hope to see you again~";
            currentMoneyshow.text = "Your wallet: $" + itemUnit.money;
        }
    }

    public void onResetButton() 
    {
        total = 0;
        colaBuy = 0;
        friesBuy = 0;
        hamburgerBuy = 0;

        Colaamount.text = colaBuy.ToString();
        Hamburgeramount.text = hamburgerBuy.ToString();
        friesamount.text = friesBuy.ToString();
        currentMoneyshow.text = "Your wallet: $" + itemUnit.money;
        totalamountshow.text = "Total amount: $" + total.ToString();

    }
    
    public void onResetButton_healStation() 
    {
        total = 0;
        FullHealBuy = 0;
        ATboosterBuy = 0;
        FullHeal_amount.text = FullHealBuy.ToString();
        ATbooster_amount.text = ATboosterBuy.ToString();
        currentMoneyshow.text = "Your wallet: $" + itemUnit.money;
        totalamountshow.text = "Total amount: $" + total.ToString();
    }


}
