using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;
    public int exp;
    public int expToLvlUp;

    public int damage;

    public int maxHP;
    public int currentHP;

    public bool TakeDamage(int dmg) {
        currentHP -= dmg;

        if (currentHP <= 0)
        {
            return true;
        }
        else
            return false;
    }

    public void Heal(int amount) 
    {
        currentHP += amount;
        if (currentHP > maxHP)
            currentHP = maxHP;
    }
    public void weaponPurchase(int dmg) 
    {
        damage += dmg;
    }
    public void atGaugePurchase() 
    {
        maxHP += maxHP;
        currentHP += maxHP;
        if (currentHP > maxHP) 
        {
            currentHP = maxHP;
        }
    }
    public void damageSet(int dmg) 
    {
        damage = dmg;
    }
    public void HpSet(int hp) 
    {
        maxHP = hp;
        if (currentHP > maxHP) 
        {
            currentHP = hp;
        }
    }
}
