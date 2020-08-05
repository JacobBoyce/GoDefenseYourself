using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/* PAUSE GAME METHOD LIVES HERE */

public class TouchController : MonoBehaviour
{
    public string weaponSelected;
    // Start is called before the first frame update
   
    public GameObject equipped;
    public GameObject gunPos;
    public GameObject gLPrefab, lGPrefab, iGPrefab;
    private GameObject gLObj, lGObj, iGObj;
    public GameObject cooldownSprite; 
    public Canvas canvasObj;
    private GameObject tempCooldownObj;
    public bool pressed = false;

     void Start()
    {
        weaponSelected = PlayerPrefs.GetString("weaponSelect");

        if(weaponSelected.Equals("Grenade"))
        {   
            gLObj = Instantiate(gLPrefab, this.transform);
            gLObj.transform.position = gunPos.transform.position;
            gLObj.transform.rotation = gunPos.transform.rotation;
            equipped = gLObj;
            //add stat values here for weapon class and grenade launcher class
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

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            //check if touched UI
            int id = touch.fingerId;
            if (!EventSystem.current.IsPointerOverGameObject(id))
            {
                equipped.GetComponentInChildren<Weapon>().Shoot();

                switch (touch.phase)
                {
                    //When a touch has first been detected, change the message and record the starting position
                    case TouchPhase.Began:
                        if(pressed == false)
                        {
                            tempCooldownObj = Instantiate(cooldownSprite, canvasObj.transform.position, canvasObj.transform.rotation);
                            tempCooldownObj.transform.SetParent(canvasObj.transform);
                            tempCooldownObj.transform.localScale = new Vector3(1,1,1);
                            tempCooldownObj.GetComponent<Image>().fillAmount = .5f;
                            pressed = true;
                        }
                        break;

                    //Determine if the touch is a moving touch
                    case TouchPhase.Moved:

                        break;

                    case TouchPhase.Ended:
                        Destroy(tempCooldownObj);
                        pressed = false;
                        break;
                }
                
                if(pressed == true)
                {
                    //update the position of the cooldown to players finger
                    tempCooldownObj.transform.position = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y + 120, 0);

                    tempCooldownObj.GetComponent<Image>().fillAmount = (1-(equipped.GetComponentInChildren<Weapon>().cooldown / equipped.GetComponentInChildren<Weapon>().FireRateS)/2)-.5f;
                }
            }        
        }
    }

    public void PauseOrResumeGame()
    {
        this.GetComponent<GryoCam>().SwitchGyro();
        equipped.GetComponentInChildren<Weapon>().didCannonShot = true;
        
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
