using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Controller : MonoBehaviour {

    [SerializeField]
    Text[] Texts; // 0 - HT; 1 - HP; 2 - 
    [SerializeField]
    Button[] Buttons;

    static Text[] myTexts;
    static Button[] myButtons;


    void Start() {
        myTexts = Texts;
        myButtons = Buttons;
	}

	void Update () {
		
	}

    public static void UpdateHyperTokensText(string value)
    {
        myTexts[0].text = "HT: " + value;
    }

    public static void UpdateHP(string value)
    {
        myTexts[1].text = "HP: " + value;
    }

    public static void UpdateMetalScrapsText(string value)
    {
        myTexts[2].text = "Metal: " + value;
    }
    public static void UpdateEnergyCoresText(string value)
    {
        myTexts[3].text = "EnergyCores: " + value;
    }
}
