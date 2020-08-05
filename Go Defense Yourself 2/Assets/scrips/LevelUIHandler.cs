using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIHandler : MonoBehaviour
{
    public GameObject selectedImg, playButton, difficulty;

    public void Selected()
    {
        selectedImg.SetActive(true);
        playButton.SetActive(false);
        difficulty.SetActive(true);
    }

    public void Deselected()
    {
        selectedImg.SetActive(false);
        playButton.SetActive(true);
        difficulty.SetActive(false);
    }
}
