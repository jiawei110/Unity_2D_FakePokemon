using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public string unitName; 
    public int unitLevel;
    public int exp;
    public int damage;
    public int expToLvlUp;
    public int maxHP;
    public int currentHP;

    public int money;

    public int hamburger;
    public int cola;
    public int fries;

    public int ATbooster;
    public int fullHeal;

    public bool gun;
    public bool knife;
    public bool ATgauge;

    public PlayerData (Unit player , ItemUnit item) 
    {
        unitName = player.unitName;
        unitLevel = player.unitLevel;
        exp = player.exp;
        damage = player.damage;
        expToLvlUp = player.expToLvlUp;

        currentHP = player.currentHP;
        maxHP = player.maxHP;

        money = item.money;                   
        cola = item.cola;
        fries = item.fries;
        hamburger = item.hamburger;
        ATbooster = item.ATbooster;
        fullHeal = item.fullHeal;
        gun = item.gun;
        knife = item.knife;
        ATgauge = item.ATgauge;
    }

}
