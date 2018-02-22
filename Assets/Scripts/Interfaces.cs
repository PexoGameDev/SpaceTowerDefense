using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    void SetVariants(bool[] Variants);
    void Die();
    void GetDamaged(int DamageValue, Turrets.DamageType DamgeType);
    GameObject GetGameObject();
    void UpdateHealthBar(float HealthPercentage);
    float GetDistance();
    int GetDamage();
}

public interface ITurretUpgradeModule
{
    void Upgrade();
    void Sell();
    int GetUpgradePrice();
    int GetSellPrice();
    string GetDamage();
    string GetRange();
    string GetName();
    string GetShootingFrequency();
    int GetTurretLevel();
    GameObject GetRangeIndicator();
}

public interface ITurretShootingModule
{
    void StartShooting(IEnemy Target);
    void StopShooting();
    void UpgradeTurretShooting();
    string GetDamage();
    string GetShootingFrequency();
}