using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class EnemyDmg : MonoBehaviour
{
    public List<ITakeDamage> Damageables { get; } = new();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Attack(20f);
        }
    }

    public void Attack(float damageAmount)
    {
        foreach (var damageable in Damageables)
        {
            damageable.TakeDamage(damageAmount);
        }
    }
}

