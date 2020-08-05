using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIHandler : MonoBehaviour
{
    public TMP_InputField spawnEnemies, delaySpawn, damageIF, fireRateIF, velIF, blastRadIF, explForceIF;
    public Weapon glWeapon;
    public GrenadeLauncherController glCon;

    void Start()
    {
        
        spawnEnemies.text = "1";
        delaySpawn.text = "1";

        //fire rate text = weapon stat fire rate
    }

    public void PopulateValues()
    {
        glCon = GameObject.Find("GLController").GetComponent<GrenadeLauncherController>();
        glWeapon = GameObject.Find("GLController").GetComponent<Weapon>();
        damageIF.text = glWeapon.DamageS.ToString();
        fireRateIF.text = glWeapon.FireRateS.ToString();
        velIF.text = glWeapon.VelocityS.ToString();
        blastRadIF.text = glCon.BlastRadiusS.ToString();
        explForceIF.text = glCon.ExplForceS.ToString();
    }

    public void SaveValues()
    {
        glWeapon.DamageS = int.Parse(damageIF.text);
        glWeapon.FireRateS = float.Parse(fireRateIF.text);
        glWeapon.VelocityS = int.Parse(velIF.text);
        glCon.BlastRadiusS = int.Parse(blastRadIF.text);
        glCon.ExplForceS = int.Parse(explForceIF.text);
    }

    //inc/dec for fire rate 

    #region SpawnEnemies inc/dec modifiers
    public void IncNumEnemyField()
    {
        spawnEnemies.text = (int.Parse(spawnEnemies.text) + 1).ToString();
    }
    public void DecNumEnemyField()
    {
        if(!spawnEnemies.text.Equals("1"))
        {
            spawnEnemies.text = (int.Parse(spawnEnemies.text) - 1).ToString();
        }
    }
    #endregion

    #region DelaySpawn inc/dec modifiers
    public void IncDelaySpawnField()
    {
        delaySpawn.text = (int.Parse(delaySpawn.text) + 1).ToString();
    }
    public void DecDelaySpawnField()
    {
        if(!delaySpawn.text.Equals("1"))
        {
            delaySpawn.text = (int.Parse(delaySpawn.text) - 1).ToString();
        }
    }
    #endregion

    #region Damage inc/dec modifiers
    public void IncDamageField()
    {
        damageIF.text = (int.Parse(damageIF.text) + 1).ToString();
    }
    public void DecDamageField()
    {
        if(!damageIF.text.Equals("1"))
        {
            damageIF.text = (int.Parse(damageIF.text) - 1).ToString();
        }
    }
    #endregion

    #region FireRate inc/dec modifiers
    public void IncFireRateField()
    {
        fireRateIF.text = Math.Round((double.Parse(fireRateIF.text) + .05f), 2).ToString();
    }
    public void DecFireRateField()
    {
        if(!fireRateIF.text.Equals("0"))
        {
            fireRateIF.text = Math.Round((double.Parse(fireRateIF.text) - .05f), 2).ToString();
        }
    }
    #endregion

    #region Velocity inc/dec modifiers
    public void IncVelField()
    {
        velIF.text = (int.Parse(velIF.text) + 1).ToString();
    }
    public void DecVelField()
    {
        if(!velIF.text.Equals("1"))
        {
            velIF.text = (int.Parse(velIF.text) - 1).ToString();
        }
    }
    #endregion

    #region BlastRadius inc/dec modifiers
    public void IncBlastRadiusField()
    {
        blastRadIF.text = (int.Parse(blastRadIF.text) + 1).ToString();
    }
    public void DecBlastRadiusField()
    {
        if(!blastRadIF.text.Equals("1"))
        {
            blastRadIF.text = (int.Parse(blastRadIF.text) - 1).ToString();
        }
    }
    #endregion

    #region ExplosionForce inc/dec modifiers
    public void IncExplForceField()
    {
        explForceIF.text = (int.Parse(explForceIF.text) + 5).ToString();
    }
    public void DecExplForceField()
    {
        if(!explForceIF.text.Equals("1"))
        {
            explForceIF.text = (int.Parse(explForceIF.text) - 5).ToString();
        }
    }
    #endregion
}
