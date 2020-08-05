using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GryoCam : MonoBehaviour
{
    private GameObject camParent;
    public bool switchGyro = true;
    private float rotationX, minRotationX = -90, maxRotationX = 90;
    private float rotationY, minRotationY = -90, maxRotationY = 90;
	// Use this for initialization
	void Start ()
    {
        camParent = new GameObject("CamParent");
        camParent.transform.position = this.transform.position;
        this.transform.parent = camParent.transform;
        switchGyro = true;
    }
	
	void Update () {
        if(switchGyro == true)
        {
            rotationX += -Input.gyro.rotationRateUnbiased.x;
            rotationX = Mathf.Clamp(rotationX, minRotationX,maxRotationX);

            rotationY += -Input.gyro.rotationRateUnbiased.y;
            rotationY = Mathf.Clamp(rotationY, minRotationY,maxRotationY);

            camParent.transform.rotation = Quaternion.Euler(rotationX,rotationY,0);

            float z = transform.eulerAngles.z;
            camParent.transform.Rotate(0, 0, -z);
        }
	}

    public void SwitchGyro()
    {
        switchGyro = !switchGyro;
        camParent.transform.position = this.transform.position;
    }

}
