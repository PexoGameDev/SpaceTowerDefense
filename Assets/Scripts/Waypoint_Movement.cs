using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint_Movement : MonoBehaviour {

    public Vector3[] Waypoints;
    Vector3 Actual_Waypoint;
    int Actual_Waypoint_Index = 0;
    public float speed = 0.1f;
	void Start () {
        Actual_Waypoint = Waypoints[0];
	}
	
	void FixedUpdate () {
        Movement_Step();
	}

    void Movement_Step()
    {
            transform.position = Vector3.MoveTowards(transform.position, Actual_Waypoint, speed);
            if (Vector3.Distance(transform.position, Actual_Waypoint) < 0.1f)
            {
            if (Actual_Waypoint_Index < Waypoints.Length - 1)
            {
                Actual_Waypoint_Index++;
                Actual_Waypoint = Waypoints[Actual_Waypoint_Index];
            }

            else
            {
                Game_Controller.HP -= gameObject.GetComponent<IEnemy>().GetDamage();
                Destroy(gameObject);
            }
            }
    }
}
