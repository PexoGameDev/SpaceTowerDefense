using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs_Controller : MonoBehaviour {

    public GameObject myKinetic_Barriers_Prefab;

    public static GameObject Kinetic_Barriers_Prefab;

    void Awake () {
        InitializePrefabs();
    }
	
    void InitializePrefabs()
    {
        Kinetic_Barriers_Prefab = myKinetic_Barriers_Prefab;
    }
}
