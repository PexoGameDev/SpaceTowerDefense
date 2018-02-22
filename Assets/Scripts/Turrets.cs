using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour {

    public enum TurretType
    {
        Gatling_gun, Sniper_Tower, Laser_Turret, Plasma_Cannon, Rocket_launcher, Slower
    }
    public enum DamageType
    {
        Ballistic, Energy
    }
}
