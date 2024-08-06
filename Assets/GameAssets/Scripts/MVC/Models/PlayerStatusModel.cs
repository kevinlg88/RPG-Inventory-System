using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusModel
{
    private int baseMaxHealth;
    private int totalMaxHealth;
    private int baseResistance;
    private int totalResistance;
    private int baseAttack;
    private int totalAttack;
    private int baseVelocity;
    private int totalVelocity;

    public PlayerStatusModel()
    {
        baseMaxHealth = 500;
        baseResistance = 20;
        baseAttack = 30;
        baseVelocity = 15;
        totalMaxHealth = baseMaxHealth;
        totalResistance = baseResistance;
        totalAttack = baseAttack;
        totalVelocity = baseVelocity;
    }

    public void AddMaxHealth(int maxHealth)
    {
        totalMaxHealth += maxHealth;
    }

    public void AddResistance(int resistance)
    {
        totalResistance += resistance;
    }

    public void AddAttack(int attack)
    {
        totalAttack += attack;
    }

    public void AddVelocity(int velocity)
    {
        totalVelocity += velocity;
    }

    public void RemoveMaxHealth(int maxHealth)
    {
        totalMaxHealth += maxHealth;
    }

    public void RemoveResistance(int resistance)
    {
        totalResistance -= resistance;
    }

    public void RemoveAttack(int attack)
    {
        totalAttack -= attack;
    }

    public void RemoveVelocity(int velocity)
    {
        totalVelocity -= velocity;
    }

    public int GetMaxHealth()
    {
        return totalMaxHealth;
    }

    public int GetResistance()
    {
        return totalResistance;
    }

    public int GetAttack()
    {
        return totalAttack;
    }

    public int GetVelocity()
    {
        return totalVelocity;
    }

}
