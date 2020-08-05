using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
** TO ADD A LEVEL **
    1) In unity, make another Level prefab (do what ya gotta do with the new images and scene).
    2) Drag 'n' drop it to the -Content (Level Selector Controller)- object.
    3) In the inspector, add the new level prefab to the list under this script
    4) Select the -PlayButton- object and add the -Content (Level Selector Controller)- object to the OnClick event
    5) Select this script and use the function -SelectLevel- (level should auto populate with the parent level)
*/
public class LevelSelectorController : MonoBehaviour
{
    public List<GameObject> levelUI = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < levelUI.Count; i++)
        {
            levelUI[i].GetComponent<LevelUIHandler>().Deselected();
        }
    }

    public void SelectLevel(GameObject level)
    {
        for(int i = 0; i < levelUI.Count; i++)
        {
            if(level == levelUI[i])
            {
                levelUI[i].GetComponent<LevelUIHandler>().Selected();
                // This is where you load level info to player prefs 
                //or in the difficulty button select
            }
            else
            {
                levelUI[i].GetComponent<LevelUIHandler>().Deselected();
            }
        }
    }
}
