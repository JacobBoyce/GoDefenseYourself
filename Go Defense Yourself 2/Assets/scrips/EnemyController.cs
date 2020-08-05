using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyController : MonoBehaviour
{
    private float hp;
    public float maxHP = 50f;
    private GameObject wallPosObj;
    public float WalkingSpeed = .005f;
    public bool attacked = false;
    public float staggerTime;

    public float attackCooldown, attackMaxCooldown = 1f;
    public Image hpBar;
    public Canvas hpCanvas;
    private Quaternion hpBarStartRot;
    public TextMeshProUGUI hpText;

    public int damage = 10;

    public enum EnemyStates
    {
        MOVE,
        ATTACK,
        STAGGER,
    }

    public EnemyStates currentState;

    // Use this for initialization
    void Start ()
    {
        hp = maxHP;
        attackCooldown = attackMaxCooldown;
        wallPosObj = GameObject.Find("Wall");
        IncreaseHP(PlayerPrefs.GetInt("waveNum"));
        hpText.text = hp.ToString();
        hpBarStartRot = this.transform.rotation;
	}

    // Update is called once per frame
    void Update()
    {
        //hpBar.transform.rotation = hpBarStartRot;
        //hpCanvas.GetComponentInChildren<Transform>().rotation = hpBarStartRot;
        hpCanvas.transform.SetPositionAndRotation(this.transform.position + new Vector3(0,5,-3), hpBarStartRot);
        if(hp <= 0)
        {
            GameObject.Find("Wave Controller").GetComponent<WaveController>().enemiesLeft--;
            GameObject.Find("Controller").GetComponent<UpgradeGuns>().money += (3+ GameObject.Find("Wave Controller").GetComponent<WaveController>().currentWave);
            Destroy(gameObject);
        }
        switch (currentState)
        {
            case (EnemyStates.MOVE):
                if (Vector3.Distance(transform.position, wallPosObj.transform.position) > 25)
                {
                    transform.position = Vector3.MoveTowards(transform.position, wallPosObj.transform.position, WalkingSpeed * Time.deltaTime);
                    break;
                }
                else
                {
                    currentState = EnemyStates.ATTACK;
                }
                break;

            case (EnemyStates.STAGGER):
                if (staggerTime > 0)
                {
                    staggerTime -= Time.deltaTime;
                }
                else if (staggerTime <= 0)
                {
                    staggerTime = 0;
                    currentState = EnemyStates.MOVE;
                }
                break;
                

            case (EnemyStates.ATTACK):
                if (Vector3.Distance(transform.position, wallPosObj.transform.position) > 25)
                {
                    currentState = EnemyStates.MOVE;
                    break;
                }
                else
                {
                    if(attacked == false)
                    {
                        attackCooldown = attackMaxCooldown;
                        GameObject.Find("Wall").GetComponent<WallController>().TakeDamage(damage);
                        attacked = true;
                    }
                    if(attacked == true)
                    {
                        if(attackCooldown > 0)
                        {
                            attackCooldown -= Time.deltaTime;
                        }
                        else
                        {
                            attacked = false;
                            break;
                        }
                    }
                }
            break;
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        GameObject temp = collision.gameObject;
        if(temp.tag == "bullet")
        {
            staggerTime += 1f;
            if(currentState != EnemyStates.STAGGER)
            {
                currentState = EnemyStates.STAGGER;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        hpBar.fillAmount = hp/maxHP;
        hpText.text = hp.ToString();
    }

    /* TAKE DAMAGE ON VELOCITY
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            
            if(Mathf.RoundToInt(collision.relativeVelocity.magnitude) > 10)
            {
                damage = Mathf.RoundToInt(collision.relativeVelocity.magnitude);
            }
            
        }
    }
*/

    public void IncreaseHP(int waveNum)
    {
        //if(waveNum != 0 || waveNum!= 1)
        //{
            for(int i = 2; i < waveNum; i++)
            {
                maxHP += Mathf.Round(2 + (maxHP*.02f));
                damage++;
            }
            hp = maxHP;
        //}
    }
}
