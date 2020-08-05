using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelect : MonoBehaviour
{
    public Button playButton; 

    public void SelectGrenade()
    {
        PlayerPrefs.SetString("weaponSelect", "Grenade");
        playButton.interactable = true;
    }

    public void SelectLightning()
    {
        PlayerPrefs.SetString("weaponSelect", "Lightning");
        playButton.interactable = true;
    }

    public void SelectIce()
    {
        PlayerPrefs.SetString("weaponSelect", "Ice");
        playButton.interactable = true;
    }
}
