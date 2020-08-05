using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 2f;
    float countdown;

    public GameObject explosionEffect, tempExplosionEffect;
    private GrenadeLauncherController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("GLController").GetComponent<GrenadeLauncherController>();
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        countdown -= Time.deltaTime;
        if(countdown <= 0 && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
        */
    }

    void Explode()
    {
        //explosion damage to enemy
        //show effect
        tempExplosionEffect = Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, controller.BlastRadiusS);
        foreach(Collider nearbyObj in colliders)
        {
            Rigidbody rb = nearbyObj.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(controller.ExplForceS, this.transform.position, controller.BlastRadiusS, 1f);
                if(nearbyObj.tag == "Enemy")
                {
                    nearbyObj.gameObject.SendMessage("TakeDamage", Mathf.RoundToInt(controller.GetComponent<Weapon>().DamageS*.6f));
                }
            }
        }
        Destroy(gameObject);
    }


    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Terrain")
        {
            Explode();
            Destroy(tempExplosionEffect, 2f);
        }
        else if (other.gameObject.tag == "Enemy")
        {
            //direct hit damage to enemy
            Explode();
            other.gameObject.SendMessage("TakeDamage", controller.GetComponent<Weapon>().DamageS + (Mathf.RoundToInt(controller.GetComponent<Weapon>().DamageS*.1f)));
            Destroy(tempExplosionEffect, 2f);
        }
    }
}
