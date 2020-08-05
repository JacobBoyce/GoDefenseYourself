using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    #region Base Vars
        public GameObject bullet, spawnPoint;
        public ForceMode forceMode;
        public LayerMask layerMask;
        public float cooldown;
        public bool didCannonShot = false;
    #endregion

    #region Line Rend Vars
        public LineRenderer lineRend;
        //base values for line renderer
        private float timeRes = 0.02f, maxTime = 10;
    #endregion

    #region Stat Vars
        public WeaponStat damage;
        public WeaponStat fireRate;
        public WeaponStat velocity;

        public float DamageB{get{return damage.StatBaseValue;} set{damage.StatBaseValue = value;}}
        public float FireRateB{get{return fireRate.StatBaseValue;} set{fireRate.StatBaseValue = value;}}
        public float VelocityB{get{return velocity.StatBaseValue;} set{velocity.StatBaseValue = value;}}

        public float DamageS{get{return damage.StatValue;} set{damage.StatValue = value;}}
        public float FireRateS{get{return fireRate.StatValue;} set{fireRate.StatValue = value;}}
        public float VelocityS{get{return velocity.StatValue;} set{velocity.StatValue = value;}}

        public float DamageU{get{return damage.UpgradeAmount;} set{damage.UpgradeAmount = value;}}
        public float FireRateU{get{return fireRate.UpgradeAmount;} set{fireRate.UpgradeAmount = value;}}
        public float VelocityU{get{return velocity.UpgradeAmount;} set{velocity.UpgradeAmount = value;}}

    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        gameObject.SendMessage("InitValues");
    }

    // Update is called once per frame
    void Update()
    {
        #region line renderer
        Vector3 velVector = transform.forward * VelocityS;
        lineRend.positionCount = (int)(maxTime / timeRes);
        int index = 0;
        Vector3 currentPos = transform.position;

	    for(float t = 0.0f; t < maxTime; t+= timeRes)
        {
            lineRend.SetPosition(index, currentPos);
            RaycastHit hit;
            if(Physics.Raycast(currentPos,velVector, out hit, velVector.magnitude*timeRes, layerMask))
            {
                lineRend.positionCount = index + 2;
                lineRend.SetPosition(index + 1, hit.point);
                break;
            }

            currentPos += velVector * timeRes;
            velVector += Physics.gravity* timeRes;
            index++;
        }
        #endregion

        if(didCannonShot)
        {
            if (cooldown < fireRate.StatValue)
            {
                cooldown += Time.deltaTime;
                //cooldownIcon.fillAmount = cooldown / shootSpeed;
            }
            else
            {
                didCannonShot = false;
                cooldown = 0;
            }
        }
    }

    public void Shoot()
    {
        if(!didCannonShot)
        {
            didCannonShot = true;
            GameObject tempBall;
            tempBall = Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
            //set ball damage here
            tempBall.GetComponent<BulletController>().SetDamage(damage.StatValue);
            tempBall.GetComponent<Rigidbody>().AddForce(transform.forward * velocity.StatValue, forceMode);
            //source.PlayOneShot(cannonShot);
        }
    }

    
}