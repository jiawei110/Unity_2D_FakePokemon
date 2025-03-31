using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyData 
{
    public bool whiteGirl;
    public bool purpleguy;
    public bool berserker;
    public bool oldman;
    public bool yamada;
    public bool activegirl;
    public int whoToBattle;
    public EnemyData() 
    {
        whiteGirl = true;
        purpleguy = true;
        berserker = true;
        oldman = true;
        yamada = true;
        activegirl = true;

    }
    public void setComponent(int whoToBattle)
    {
        this.whoToBattle = whoToBattle;
    }
    public EnemyData(EnemyData data) 
    {
        whiteGirl = data.whiteGirl;
        purpleguy = data.purpleguy;
        berserker = data.berserker;
        oldman = data.oldman;
        yamada = data.yamada;
        activegirl = data.activegirl;
        whoToBattle = data.whoToBattle;
    }
}
