using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WallController : MonoBehaviour
{
    public float wallHP = 100, wallMaxpHP = 100;
    public int upgradeCost = 100, repairCost = 50;
    public bool damageTook = false;

    private float damageCooldown, cooldownMax = .25f;
    public Image hpBar;
    public Text wallHPText, upgradeCostText, repairCostText;
    // Start is called before the first frame update
    void Start()
    {
        damageCooldown = cooldownMax;
        wallHP = wallMaxpHP;
        wallHPText.text = wallHP + " / " + wallMaxpHP;
        upgradeCostText.text = "$ " + upgradeCost + "\nHP Increase: 100";
        repairCostText.text = "$ " + repairCost + "\nHP Repair: 25";
    }

    void Update()
    {
        if(wallHP <= 0)
        {
            wallHP = 0;
            SceneManager.LoadScene("EndScene");
        }

        if(damageTook == true)
        {
            if(damageCooldown > 0)
            {
                damageCooldown -= Time.deltaTime;
            }
            else
            {
                damageTook = false;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if(damageTook == false)
        {
            wallHP -= damage;
            damageTook = true;
            damageCooldown = cooldownMax;
            hpBar.fillAmount = wallHP/wallMaxpHP;
            wallHPText.text = wallHP + " / " + wallMaxpHP;
        }
    }

    public void UpgradeHP()
    {
        if(GameObject.Find("Controller").GetComponent<UpgradeGuns>().money >= upgradeCost)
        {
            wallMaxpHP += 100;
            GameObject.Find("Controller").GetComponent<UpgradeGuns>().money -= upgradeCost;
            upgradeCost += 100;
            wallHP += 100;
            hpBar.fillAmount = wallHP/wallMaxpHP;
            upgradeCostText.text = "$ " + upgradeCost + "\nHP Increase: 100";
            wallHPText.text = wallHP + " / " + wallMaxpHP;
        }
    }

    public void RepairWall()
    {
        if(GameObject.Find("Controller").GetComponent<UpgradeGuns>().money >= repairCost)
        {
            wallHP += 25;
            if(wallHP > wallMaxpHP)
            {
                wallHP = wallMaxpHP;
            }
            GameObject.Find("Controller").GetComponent<UpgradeGuns>().money -= repairCost;
            hpBar.fillAmount = wallHP/wallMaxpHP;
            wallHPText.text = wallHP + " / " + wallMaxpHP;
        }
    }
}
