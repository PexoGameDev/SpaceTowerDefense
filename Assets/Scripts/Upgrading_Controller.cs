using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Upgrading_Controller : MonoBehaviour {
    public static ITurretUpgradeModule ChosenTurret;
    public Button[] Buttons;
    public Text[] Texts;
    public GameObject UpgradePanel;

    static GameObject myUpgradePanel;
    static Button[] myButtons;
    static Text[] myTexts;

    static System.Text.StringBuilder Description;

    static int hyperTokens = 1000;
    static int metalScraps = 2;
    static int energyCores = 2;

    public static int HyperTokens {
        get { return hyperTokens; }
        set { hyperTokens = value; UI_Controller.UpdateHyperTokensText(hyperTokens.ToString()); } }
    public static int MetalScraps
    {
        get { return metalScraps; }
        set { metalScraps = value; UI_Controller.UpdateMetalScrapsText(metalScraps.ToString()); }
    }
    public static int EnergyCores
    {
        get { return energyCores; }
        set { energyCores = value; UI_Controller.UpdateEnergyCoresText(energyCores.ToString()); }
    }
    void Start () {
        myButtons = Buttons;
        myTexts = Texts;
        myUpgradePanel = UpgradePanel;
        Description = new System.Text.StringBuilder();
        myUpgradePanel.SetActive(false);
        UI_Controller.UpdateHyperTokensText(hyperTokens.ToString());
        UI_Controller.UpdateEnergyCoresText(energyCores.ToString());
        UI_Controller.UpdateMetalScrapsText(metalScraps.ToString());
    }
	
	void Update () {

	}

    public static void ChangeChosenTurret(ITurretUpgradeModule NewChosenTurret)
    {
        if (ChosenTurret!=null)
        ChosenTurret.GetRangeIndicator().SetActive(false);

        myUpgradePanel.SetActive(true);
        ChosenTurret = NewChosenTurret;
        ChosenTurret.GetRangeIndicator().SetActive(true);
        myButtons[0].onClick.RemoveAllListeners();
        myButtons[1].onClick.RemoveAllListeners();
        myButtons[2].onClick.RemoveAllListeners();

        myButtons[0].GetComponentInChildren<Text>().text = string.Format("UPGRADE \n [{0}]", ChosenTurret.GetUpgradePrice());
        myButtons[1].GetComponentInChildren<Text>().text = string.Format("SELL \n [{0}]", ChosenTurret.GetSellPrice());
        myButtons[2].GetComponentInChildren<Text>().text = string.Format("");

        myButtons[0].onClick.AddListener(delegate { ChosenTurret.Upgrade(); });
        myButtons[1].onClick.AddListener(delegate { ChosenTurret.Sell(); myUpgradePanel.SetActive(false); });
        myButtons[2].onClick.AddListener(delegate { /*????*/ });

        Description.Remove(0, Description.Length);
        Description.Append("Damage: ");
        Description.AppendLine(ChosenTurret.GetDamage());
        Description.Append("Shooting Frequency: ");
        Description.AppendLine(ChosenTurret.GetShootingFrequency());
        Description.Append("Range: ");
        Description.AppendLine(ChosenTurret.GetRange());
        myTexts[0].text = ChosenTurret.GetName();
        myTexts[1].text = Description.ToString();
    }
}
