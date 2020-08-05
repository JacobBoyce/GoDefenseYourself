using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChamber : MonoBehaviour
{
    public string weaponSelected;
    public GameObject equipped;
    public GameObject gunPos;
    public GameObject gLPrefab, lGPrefab, iGPrefab;
    private GameObject gLObj, lGObj, iGObj;

    public List<GameObject> menus = new List<GameObject>();


    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(new Vector3(0,-1,0) * (30* Time.deltaTime));
        }
        else if(Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(new Vector3(0,1,0) * (30* Time.deltaTime));
        }
        else if(Input.GetKey(KeyCode.W))
        {
            this.transform.Rotate(new Vector3(-1,0,0) * (30* Time.deltaTime));
        }
        else if(Input.GetKey(KeyCode.S))
        {
            this.transform.Rotate(new Vector3(1,0,0) * (30 * Time.deltaTime));
        } 

        if(Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void EquipGun()
    {
        weaponSelected = PlayerPrefs.GetString("weaponSelect");

        if(weaponSelected.Equals("Grenade"))
        {   
            gLObj = Instantiate(gLPrefab, this.transform);
            gLObj.transform.position = gunPos.transform.position;
            gLObj.transform.rotation = gunPos.transform.rotation;
            equipped = gLObj;
        }
        else if(weaponSelected.Equals("Lightning"))
        {
            lGObj = Instantiate(lGPrefab, this.transform);
            lGObj.transform.position = gunPos.transform.position;
            lGObj.transform.rotation = gunPos.transform.rotation;
            equipped = lGObj;
            
        }
        else if(weaponSelected.Equals("Ice"))
        {
            iGObj = Instantiate(iGPrefab, this.transform);
            iGObj.transform.position = gunPos.transform.position;
            iGObj.transform.rotation = gunPos.transform.rotation;
            equipped = iGObj;
        }
    }

    public void Pause()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
    }

    public void Shoot()
    {
        equipped.GetComponentInChildren<Weapon>().Shoot();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
