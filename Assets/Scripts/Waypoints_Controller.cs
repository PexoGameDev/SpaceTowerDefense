using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
public class Waypoints_Controller : MonoBehaviour {
    public Transform[] Waypoints_Transforms;
    [HideInInspector]
    public Vector3[] Waypoints;
	void Start () {
        //Waypoints = FindWaypoints();
        Waypoints = Convert_Transforms_To_Waypoints();
	}

    // USE THIS IF THERE IS MORE THAN ONE PATH ON MAP
    Vector3[] Convert_Transforms_To_Waypoints()
    {
        Vector3[] TemporaryWaypointsArrays = new Vector3[Waypoints_Transforms.Length];
        int ArrayIndex = 0;
         foreach (Transform waypoint in Waypoints_Transforms)
            {
                TemporaryWaypointsArrays[ArrayIndex] = waypoint.transform.position;
                ArrayIndex++;
            }
        return TemporaryWaypointsArrays;
    }

    // USE THIS IF THERE IS ONLY ONE PATH ON MAP
	Vector3[] FindWaypoints()
    {
        Transform[] Temporary_All_Waypoints = GameObject.Find("EnemyWaypoints").GetComponentsInChildren<Transform>();
        Vector3[] Temporary_Waypoints = new Vector3[Temporary_All_Waypoints.Length];
        int index = 0;
        foreach (Transform waypoint in Temporary_All_Waypoints)
        {
            Temporary_Waypoints[index] = waypoint.transform.position;
            index++;
        }
        return Temporary_Waypoints;
    }
}
