using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class statue_defense_1 : Building
// statue_defense_1: defense+2; money=150, stone=5
// statue_defense_2: defense+4; money=400, wood=20, stone=20
// statue_defense_3: defense+8; money=1000, wood=50, stone=50, iron=10
{
    public int defense;

    void Start()
    {
        level = 1;
        name = "Defense Statue 1";
        defense = 2;
        Info = "Defense Statue 1: defense+2";
        GameObject.Find("Hero").GetComponent<HeroBehavior>().Defense += defense;
    }
    
    void Update()
    {
        if (level == 2)
        {
            name = "Defense Statue 2";
            defense = 4;
            Info = "Defense Statue 2: defense+4";
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("defense2");
        }

        if (level == 3)
        {
            name = "Defense Statue 3";
            defense = 8;
            Info = "Defense Statue 3: defense+8";
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("defense3");
        }
    }

    private void OnMouseDown()
    {
        if (level == 1)
        {
            if (!BuildMenu.BuildingFlag && GameManager.getGM.GetGameStatus() != GameManager.GameStatus.Bagging)
            {
                if (GameManager.getGM.GetGameStatus() == GameManager.GameStatus.Running)
                    GameManager.getGM.SwitchToUpgrading();
                GameObject.Find("Canvas").transform.Find("Upgrade").gameObject.SetActive(true);
                GameObject.Find("Upgrade").GetComponent<UpgradingMode>().building = gameObject;

                GameObject.Find("Upgrade").GetComponent<UpgradingMode>().money = 400;
                GameObject.Find("Upgrade").GetComponent<UpgradingMode>().wood = 20;
                GameObject.Find("Upgrade").GetComponent<UpgradingMode>().stone = 20;
                GameObject.Find("Upgrade").GetComponent<UpgradingMode>().level = 2;
                GameObject.Find("Upgrade").GetComponent<UpgradingMode>().defense = 2;
                GameObject.Find("UpgradeText").GetComponent<Text>().text = "Are you sure to upgrade Defense Statue 1?\n It needs money=400, wood=20 and stone=20";
            }
        }

        if (level == 2)
        {
            if (!BuildMenu.BuildingFlag && GameManager.getGM.GetGameStatus() != GameManager.GameStatus.Bagging)
            {
                if (GameManager.getGM.GetGameStatus() == GameManager.GameStatus.Running)
                    GameManager.getGM.SwitchToUpgrading();

                GameObject.Find("Canvas").transform.Find("Upgrade").gameObject.SetActive(true);
                GameObject.Find("Upgrade").GetComponent<UpgradingMode>().building = gameObject;

                GameObject.Find("Upgrade").GetComponent<UpgradingMode>().money = 1000;
                GameObject.Find("Upgrade").GetComponent<UpgradingMode>().wood = 50;
                GameObject.Find("Upgrade").GetComponent<UpgradingMode>().stone = 50;
                GameObject.Find("Upgrade").GetComponent<UpgradingMode>().iron = 10;
                GameObject.Find("Upgrade").GetComponent<UpgradingMode>().level = 3;
                GameObject.Find("Upgrade").GetComponent<UpgradingMode>().defense = 4;
                GameObject.Find("UpgradeText").GetComponent<Text>().text = "Are you sure to upgrade Defense Statue 2?\n It needs money=1000, wood=50, stone=50 and iron=10";
            }
        }
    }
    
}