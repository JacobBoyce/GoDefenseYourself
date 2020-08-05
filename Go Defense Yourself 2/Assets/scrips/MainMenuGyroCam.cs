using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuGyroCam : MonoBehaviour
{
    private GameObject camParent;
    public bool switchGyro = false;
	// Use this for initialization
	void Start ()
    {
        camParent = new GameObject("CamParent");
        camParent.transform.position = this.transform.position;
        this.transform.parent = camParent.transform;
        Input.gyro.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.gyro.enabled == true)
        {
            camParent.transform.Rotate(0, -Input.gyro.rotationRateUnbiased.y, 0);
            //this.transform.Rotate(-Input.gyro.rotationRateUnbiased.x, 0, 0);
        }
	}

    public void SwitchGyro()
    {
        switchGyro = !switchGyro;
        Input.gyro.enabled = switchGyro;
        camParent.transform.position = this.transform.position;
        Debug.Log(switchGyro);
    }
}
