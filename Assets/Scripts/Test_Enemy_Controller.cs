using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Enemy_Controller : MonoBehaviour, IEnemy
{
    /*VARIANTS*/
    public bool isInvisible = false;
    public bool isQuicker = false;
    public bool isTougher = false;
    public bool hasArmor = false;
    public bool hasEnergyShields = false;
    public bool hasKineticBarries = false;
    public int DamageResistance = 0;
   

    [SerializeField]
    Enemies.EnemyType Type;
    [SerializeField]
    int KineticBarriersCharges = 0;
    [SerializeField]
    int MaxHP = 1000;

    GameObject MyHealthBar;
    int HP;
    float distance;
    float instantiateTime;

    private void Start()
    {
        instantiateTime = Time.timeSinceLevelLoad;
        HP = MaxHP;
        MyHealthBar = transform.GetChild(0).gameObject;

        
    }
    public void SetVariants(bool[] Variants)//bool Invisible, bool Quicker, bool Tougher, bool Armor, bool EnergyShields, bool KineticBarriers, bool DamageResistance
    {
        isInvisible = Variants[0];
        isQuicker = Variants[1];
        isTougher = Variants[2];
        hasArmor = Variants[3];
        hasEnergyShields = Variants[4];
        hasKineticBarries = Variants[5];

        if (hasKineticBarries)
        {
            KineticBarriersCharges = 5;
            Instantiate(Prefabs_Controller.Kinetic_Barriers_Prefab, transform);
        }
        if(isQuicker)
        {
            HP /= 2;
        }
        if(isTougher)
        {
            HP *= 2;
        }

        HP = MaxHP;

        if (Variants[6])
            DamageResistance = MaxHP / 10;
    }

    public void GetDamaged(int DamageValue, Turrets.DamageType DamageType)
    {
        if (KineticBarriersCharges > 0)
        {
            KineticBarriersCharges--;
            if (KineticBarriersCharges <= 0)
                DisableBarriers();
        }
        else
        {
            if (DamageValue >= DamageResistance && !((hasArmor && DamageType == Turrets.DamageType.Ballistic) || (hasEnergyShields && DamageType == Turrets.DamageType.Energy)))
            {
                HP -= DamageValue;
                if (HP <= 0)
                {
                    HP = 0;
                    Die();
                }
                UpdateHealthBar((float)HP / MaxHP);
            }
        }
    }

    void DisableBarriers()
    {
        hasKineticBarries = false;
        transform.GetChild(1).gameObject.SetActive(false);
    }
    public void Die()
    {
        Upgrading_Controller.HyperTokens += Enemies.EnemiesList[Type].HyperTokens;
        if (hasArmor)
            Upgrading_Controller.MetalScraps += 1;
        if (hasEnergyShields)
            Upgrading_Controller.EnergyCores += 1;
        Destroy(gameObject);
    }

    public GameObject GetGameObject()
    {
            return gameObject;
    }
    public void UpdateHealthBar(float HealthPercentage)
    {
        MyHealthBar.transform.localScale = new Vector3(HealthPercentage, 0.2f, 0.2f);
    }
    public float GetDistance()
    {
        return (Time.timeSinceLevelLoad- instantiateTime)*Enemies.EnemiesList[Type].speed;
    }
    public int GetDamage()
    {
        return Enemies.EnemiesList[Type].damage;
    }
}
