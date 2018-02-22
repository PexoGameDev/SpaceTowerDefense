using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Enemy
{
    public Enemy(string myName, float mySpeed, int myHealth, int myHyperTokens, int myDamage, GameObject myPrefab)
    {
        name = myName;
        speed = mySpeed;
        health = myHealth;
        HyperTokens = myHyperTokens;
        damage = myDamage;
        prefab = myPrefab;
    }

    public string name;
    public float speed;
    public int health;
    public int HyperTokens;
    public int damage;
    public GameObject prefab;
}

public class Enemies : MonoBehaviour {

    public GameObject[] EnemyPrefabs;


    public static GameObject[] myEnemyPrefabs;
    public static Dictionary<EnemyType,Enemy> EnemiesList;
    public enum EnemyType
    {
        sprinter, juggernaut, marine, boss
    }

    private void Awake()
    {
        myEnemyPrefabs = EnemyPrefabs;
        DeclareEnemies();

    }

    void DeclareEnemies()
    {
        Enemy Sprinter = new Enemy("Sprinter", 0.2f, 500, 25, 500, myEnemyPrefabs[0]);
        Enemy Marine = new Enemy("Marine", 0.1f, 1000, 25, 1000, myEnemyPrefabs[1]);
        Enemy Juggernaut = new Enemy("Juggernaut", 0.05f, 50, 2000, 2000, myEnemyPrefabs[2]);
        Enemy Boss = new Enemy("Boss", 0.05f, 8000, 500, 8000, myEnemyPrefabs[3]);

        EnemiesList = new Dictionary<EnemyType, Enemy>
        {
            { EnemyType.sprinter, Sprinter },
            { EnemyType.marine, Marine },
            { EnemyType.juggernaut, Juggernaut },
            { EnemyType.boss, Boss }
        };
    }






}
