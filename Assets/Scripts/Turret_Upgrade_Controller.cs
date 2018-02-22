using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Upgrade_Controller : MonoBehaviour, ITurretUpgradeModule
{

    public int UpgradePrice = 100;
    public int SellPrice = 50;

    int TurretLevel = 1;

    Test_Turret_Shooting myShootingModule;
    Test_Turret_Targeting myTargetingModule;

    public GameObject RangeIndicator;
    private void Start()
    {
        myShootingModule = GetComponentInParent<Test_Turret_Shooting>();
        myTargetingModule = GetComponentInParent<Test_Turret_Targeting>();
        RangeIndicator = gameObject.transform.parent.GetChild(1).gameObject;
    }

    public int GetUpgradePrice()
    {
        return UpgradePrice;
    }

    public int GetSellPrice()
    {
        return SellPrice;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Upgrading_Controller.ChangeChosenTurret(this);
        }
    }

    public void Upgrade()
    {
        if (TurretLevel < 10)
        {
            TurretLevel++;
            print(string.Format("Upgrading {0}", myShootingModule.name));
            myShootingModule.UpgradeTurretShooting();
            myTargetingModule.UpgradeRange();
            Upgrading_Controller.ChangeChosenTurret(this);
        }
    }
    public void Sell()
    {
        Upgrading_Controller.HyperTokens += SellPrice + UpgradePrice*TurretLevel/2;
        print(string.Format("Selling {0}", myShootingModule.name));
        Destroy(transform.parent.gameObject);
    }
    public string GetDamage()
    {
        return myShootingModule.GetDamage();
    }
    public string GetRange()
    {
        return myTargetingModule.GetRange();
    }
    public string GetName()
    {
        return myShootingModule.name;
    }
    public string GetShootingFrequency()
    {
        return myShootingModule.GetShootingFrequency();
    }
    public int GetTurretLevel()
    {
        return TurretLevel;
    }

    public GameObject GetRangeIndicator()
    {
        return RangeIndicator;
    }
}
