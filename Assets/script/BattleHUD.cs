using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nametext;
    public Text levelText;
    public Slider hpSlider;
    public Slider EXPSlider;

    public void SetupHUD(Unit unit) {

        nametext.text = unit.unitName;
        levelText.text = "lvl" + unit.unitLevel;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
        EXPSlider.maxValue = unit.expToLvlUp;
        EXPSlider.value = unit.exp;


    }

    public void SetHP(int hp) {
        hpSlider.value = hp;   
    }

    public void SetEXP(int EXP) {
        
        EXPSlider.value = EXP;
    }
    public void SetLvExpmax(Unit unit) 
    {
        levelText.text = "lvl" + unit.unitLevel;
        EXPSlider.maxValue = unit.expToLvlUp;
        StartCoroutine(LoadingLvlUp());
    }
    IEnumerator LoadingLvlUp()
    {
        yield return new WaitForSeconds(2f);
    }
}
