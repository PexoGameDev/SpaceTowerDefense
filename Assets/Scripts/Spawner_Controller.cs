using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Wave
{
    public Wave(Enemies.EnemyType myType, int myCount, bool[] myVariants)
    {
        Type = myType;
        Count = myCount;
        Variants = myVariants;
    }

   public Enemies.EnemyType Type;
   public int Count;
   public bool[] Variants;
}

struct Round
{
    public Round(List<Wave> myWaves)
    {
        Waves = myWaves;
    }
    public List<Wave> Waves;
}

public class Spawner_Controller : MonoBehaviour {
    [SerializeField]
    Waypoints_Controller myWaypointsController;
    [SerializeField]
    float SpawnDelayTime = 0.2f, WaveDelayTime = 0.5f, RoundDelayTime = 10f;

    Transform EnemiesGroup;
    GameObject tmpEnemy;
    Round[] Rounds;
    List<Wave> Waves;

    void Start () {
        EnemiesGroup = GameObject.Find("Enemies").transform;
        InstantiateRounds();
        StartCoroutine(SpawnEnemies());
	}

	public IEnumerator SpawnEnemies()
    {
        yield return new WaitForEndOfFrame();

        foreach (Round round in Rounds)
        {
            foreach(Wave wave in round.Waves)
            {
                    for (int i = 0; i < wave.Count; i++)
                    {
                        SpawnEnemy(wave.Type,wave.Variants);
                        yield return new WaitForSeconds(SpawnDelayTime);
                    }
                yield return new WaitForSeconds(WaveDelayTime);
            }
            yield return new WaitForSeconds(RoundDelayTime);
        }
    }

    void SpawnEnemy(Enemies.EnemyType EnemyType, bool[] Variants)
    {
        tmpEnemy = Instantiate(Enemies.EnemiesList[EnemyType].prefab, transform.position, Quaternion.identity);
        tmpEnemy.GetComponent<Test_Enemy_Controller>().SetVariants(Variants);
        tmpEnemy.GetComponent<Waypoint_Movement>().Waypoints = myWaypointsController.Waypoints;
        tmpEnemy.transform.SetParent(EnemiesGroup);
    }

    void InstantiateRounds()
    {
        Rounds = new Round[3];
        Waves = new List<Wave>();
        bool[] myVariants;//bool Invisible, bool Quicker, bool Tougher, bool Armor, bool EnergyShields, bool KineticBarriers, bool DamageResistance 

        myVariants = new bool[7] {false, false, false, false, true, false, false};
        Waves.Add(new Wave(Enemies.EnemyType.sprinter, 10, myVariants));
        Waves.Add(new Wave(Enemies.EnemyType.marine, 5, myVariants));
        Waves.Add(new Wave(Enemies.EnemyType.juggernaut, 3, myVariants));
        Rounds[0] = new Round(Waves);

        myVariants = new bool[7] { false, false, false, true, false, false, false };
        Waves.Clear();
        Waves.Add(new Wave(Enemies.EnemyType.sprinter, 10, myVariants));
        Waves.Add(new Wave(Enemies.EnemyType.marine, 8, myVariants));
        Waves.Add(new Wave(Enemies.EnemyType.juggernaut, 2, myVariants));
        Waves.Add(new Wave(Enemies.EnemyType.sprinter, 10, myVariants));
        Waves.Add(new Wave(Enemies.EnemyType.marine, 8, myVariants));
        Waves.Add(new Wave(Enemies.EnemyType.juggernaut, 2, myVariants));
        Rounds[1] = new Round(Waves);

        Waves.Clear();
        Waves.Add(new Wave(Enemies.EnemyType.marine, 12, myVariants));
        Waves.Add(new Wave(Enemies.EnemyType.juggernaut, 4, myVariants));
        Waves.Add(new Wave(Enemies.EnemyType.marine, 12, myVariants));
        myVariants = new bool[7] { false, false, false, false, false, true, false };
        Waves.Add(new Wave(Enemies.EnemyType.juggernaut, 4, myVariants));
        Rounds[2] = new Round(Waves);
    }

}