using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DummyEnemy : MonoBehaviour
{
    public float hp, maxHP;
    public float walkingSpeed, staggerTime;
    public TextMeshProUGUI hpText;
    public GameObject wallPosObj;
    public Canvas hpCanvas;
    private Quaternion hpBarStartRot;

    public enum EnemyStates
    {
        MOVE,
        ATTACK,
        STAGGER,
    }
    public EnemyStates currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyStates.MOVE;
        hpBarStartRot = this.transform.rotation;
        wallPosObj = GameObject.Find("Wall");
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "HP: " + hp.ToString();
        hpCanvas.transform.SetPositionAndRotation(this.transform.position + new Vector3(0,10,-3), hpBarStartRot);

        if (Vector3.Distance(transform.position, wallPosObj.transform.position) > 25)
        {
            transform.position = Vector3.MoveTowards(transform.position, wallPosObj.transform.position, walkingSpeed * Time.deltaTime);
        }

        if(hp <= 0)
        {
            Destroy(gameObject);
        }

        switch (currentState)
        {
            case (EnemyStates.MOVE):
                if (Vector3.Distance(transform.position, wallPosObj.transform.position) > 25)
                {
                    transform.position = Vector3.MoveTowards(transform.position, wallPosObj.transform.position, walkingSpeed * Time.deltaTime);
                    break;
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
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        GameObject temp = collision.gameObject;
        if(temp.tag == "bullet")
        {
            Debug.Log("hit");
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
        //hpBar.fillAmount = hp/maxHP;
        hpText.text = "HP: " + hp.ToString();
    }
}
