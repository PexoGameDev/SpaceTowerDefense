using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Time_Forward : MonoBehaviour {

    Button myButton;
    int SpeedIndex = 1;
    private void Start()
    {
        myButton = GetComponentInParent<Button>();
        myButton.onClick.AddListener(delegate { Time.timeScale = (SpeedIndex % 4) * .75f + 1; SpeedIndex++; });
    }
}
