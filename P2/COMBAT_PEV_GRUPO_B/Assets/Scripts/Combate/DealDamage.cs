using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;


public class DealDamage : MonoBehaviour
{
    public List<ITakeDamage> Damageables { get; } = new();

    public void OnTriggerEnter(Collider other)
    {
        var health = other.GetComponent<ITakeDamage>();

        if (health != null)
        {
            Damageables.Add(health);
        }

    }
    public void OnTriggerExit(Collider other)
    {
        var health = other.GetComponent<ITakeDamage>();
        if (health != null && Damageables.Contains(health))
        {
            Damageables.Remove(health);
        }
    }
}


