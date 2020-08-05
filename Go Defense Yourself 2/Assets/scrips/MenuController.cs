using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public List<GameObject> menus = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        ChangeMenu("StartScreen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMenu(GameObject menu)
    {
        for(int i = 0; i < menus.Count; i++)
        {
            if(menu == menus[i])
            {
                menus[i].SetActive(true);
            }
            else
            {
                menus[i].SetActive(false);
            }
        }
    }

    public void ChangeMenu(string menu)
    {
        for(int i = 0; i < menus.Count; i++)
        {
            if(menu == menus[i].name)
            {
                menus[i].SetActive(true);
            }
            else
            {
                menus[i].SetActive(false);
            }
        }
    }
}
