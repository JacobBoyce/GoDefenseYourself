using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float delayDestroy;

    public float damage, orginDamage;
    public float damageIncrease;

    void Start()
    {
        //delayDestroy = 2f;
        //damage = 25;
        //orginDamage = damage;
        //damageIncrease = 5;
    }

/*
    public void OnCollisionEnter(Collision other)
    {
        if(!collided)
        {
            if(other.gameObject.tag == "Enemy")
            {
                other.gameObject.SendMessage("TakeDamage", damage);
                collided = true;
            }
        }
        Destroy(gameObject, delayDestroy);
    }
*/
    public void UpgradeDamage()
    {
        damage += damageIncrease;
    }

    public void ResetDamage()
    {
        damage = orginDamage;
    }

    public float GetDamage()
    {
        return damage;
    }

    public void SetDamage(float dmg)
    {
        damage = dmg;
    }

    public float GetDamageInc()
    {
        return damageIncrease;
    }

    public void SetDamageInc(float dmg)
    {
        damageIncrease = dmg;
    }

    public void SetDelay(float delay)
    {
        delayDestroy = delay;
    }
}
