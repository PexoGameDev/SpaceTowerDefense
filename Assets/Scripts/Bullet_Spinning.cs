using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Spinning : MonoBehaviour {
    public GameObject MyTarget;

	void FixedUpdate () {
        transform.Rotate(0f,0f,1f);
        if (MyTarget)
            transform.position = Vector3.MoveTowards(transform.position, MyTarget.transform.position, 1f);
        else
            Destroy(gameObject);
	}
}
