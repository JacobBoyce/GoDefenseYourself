using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStat
{
    private float statValue, statOrigValue, upgradeAmount;

    public float StatValue{get{return statValue;} set{statValue = value;}}
    public float StatBaseValue{get{return statOrigValue;} set{statOrigValue = value;}}
    public float UpgradeAmount{get{return upgradeAmount;} set{upgradeAmount = value;}}

    public WeaponStat(float origStat, float upAmount)
    {
        statOrigValue = origStat;
        statValue = statOrigValue;
        upgradeAmount = upAmount;
    }
    public void ResetValues()
    {
        statValue = statOrigValue;
    }

    public void UpgradeStatValue()
    {
        statValue += upgradeAmount;
    }

    /*public void UpgradeOrigValue()
    {
        statOrigValue += upgradeAmount;
    }*/

}
