using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_Destroy_After_Seconds : MonoBehaviour {
    public float Delay;
    void Start () {
        StartCoroutine(DestroySelf());
	}
	
    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(Delay);
        Destroy(gameObject);
    }

}
