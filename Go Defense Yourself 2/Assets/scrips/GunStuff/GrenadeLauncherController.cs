using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncherController : MonoBehaviour
{
    private Weapon weaponClass;

    #region Grenade Stats
        private WeaponStat blastRadius;
        public float BlastRadiusB{get{return blastRadius.StatBaseValue;} set{blastRadius.StatBaseValue = value;}}
        public float BlastRadiusS{get{return blastRadius.StatValue;} set{blastRadius.StatValue = value;}}
        public float BlastRadiusU{get{return blastRadius.UpgradeAmount;} set{blastRadius.UpgradeAmount = value;}}

        private WeaponStat explForce;
        public float ExplForceB{get{return explForce.StatBaseValue;} set{explForce.StatBaseValue = value;}}
        public float ExplForceS{get{return explForce.StatValue;} set{explForce.StatValue = value;}}
        public float ExplForceU{get{return explForce.UpgradeAmount;} set{explForce.UpgradeAmount = value;}}

    #endregion
    void Start()
    {
        weaponClass = gameObject.GetComponent<Weapon>();
        blastRadius = new WeaponStat(10, 1);
        explForce = new WeaponStat(100, 10);        
    }

    public void InitValues()
    {
        weaponClass.damage = new WeaponStat(15f, 1f);
        weaponClass.fireRate = new WeaponStat(1.5f, 1f);
        weaponClass.velocity = new WeaponStat(50f, 1f);
    }

    void Update()
    {
       
    }
}
