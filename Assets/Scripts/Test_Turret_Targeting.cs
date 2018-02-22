using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Turret_Targeting : MonoBehaviour {

    Test_Turret_Shooting MyShootingModule;
    CircleCollider2D myCollider;
    List<IEnemy> EnemiesInRange;
    IEnemy MyTarget;

    float BaseRange = 10f;
    float ColiderStartingRadius = 5f;
    float Range = 10f;

	void Start () {
        MyShootingModule = gameObject.GetComponent<Test_Turret_Shooting>();
        myCollider = gameObject.GetComponent<CircleCollider2D>();
        MyTarget = null;
        EnemiesInRange = new List<IEnemy>();
    }

    void OnTriggerEnter2D(Collider2D Intruder)
    {
        //Adding every enemy that enters range into one list of all enemies in range
        if (Intruder.gameObject.GetComponent<IEnemy>() is IEnemy)
        {
            EnemiesInRange.Add(Intruder.gameObject.GetComponent<IEnemy>());
        }
    }

    private void OnTriggerExit2D(Collider2D Intruder)
    {
        if (Intruder.gameObject.GetComponent<IEnemy>() is IEnemy)
        {
            //Removing enemy from list of enemies in range, if he exits the range, if he's actual target - nulling MyTarget and stopping shooting coroutine.
            IEnemy tmpEnemy = Intruder.gameObject.GetComponent<IEnemy>();
            if (tmpEnemy == MyTarget){ MyTarget = null; StopShooting(); }
            EnemiesInRange.Remove(tmpEnemy);
        }
    }

    private void Update()
    {
        if (EnemiesInRange.Count > 0)
        {
            if (MyTarget == null)
            { 
                //Choosing first enemy in array, if there's no actual target
                MyTarget = EnemiesInRange[0];
                MyShootingModule.StartShooting(MyTarget);
            }
            else
            {
                //Targeting enemy that's gotten the furthest
                foreach (IEnemy enemy in EnemiesInRange)
                {
                    if (enemy.GetDistance() > MyTarget.GetDistance())
                    {
                        StopShooting();
                        MyTarget = enemy;
                        MyShootingModule.StartShooting(MyTarget);
                    }
                }
            }
        }
    }

    void StopShooting()
    {
        MyShootingModule.StopShooting();
        MyTarget = null;
    }
    public void UpgradeRange()
    {
        Range += BaseRange/10;
        myCollider.radius += ColiderStartingRadius / 10;
    }

    public string GetRange()
    {
        return Range.ToString();
    }
}
