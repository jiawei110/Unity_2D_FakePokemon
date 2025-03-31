using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_setup : MonoBehaviour
{
    public Unit playerUnit;
    public ItemUnit itemUnit;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData currentData = SaveSystem.LoadPlayer();

        playerUnit.unitName = currentData.unitName;
        playerUnit.unitLevel = currentData.unitLevel;
        playerUnit.exp = currentData.exp;
        playerUnit.damage = currentData.damage;
        playerUnit.expToLvlUp = currentData.expToLvlUp;
        playerUnit.maxHP = currentData.maxHP;
        playerUnit.currentHP = currentData.currentHP;

        itemUnit.money = currentData.money;
        itemUnit.gun = currentData.gun;
        itemUnit.knife = currentData.knife;
        itemUnit.ATgauge = currentData.ATgauge;

        itemUnit.fullHeal = currentData.fullHeal;
        itemUnit.ATbooster = currentData.ATbooster;
        itemUnit.hamburger = currentData.hamburger;
        itemUnit.cola = currentData.cola;
        itemUnit.fries = currentData.fries;
    }

}
