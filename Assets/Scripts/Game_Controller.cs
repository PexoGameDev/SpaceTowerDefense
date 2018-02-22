using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour {

    static int hp = 10000;
    public static int HP
    {
        get { return hp; }
        set { hp = value; UI_Controller.UpdateHP(hp.ToString()); }
    }

	void Start () {
        UI_Controller.UpdateHP(hp.ToString());
    }
	
	void Update () {
		
	}
}
