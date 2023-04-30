using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class DealDamage : MonoBehaviour, ITakeDamage
{
    public List<ITakeDamage> Damageables { get; } = new List<ITakeDamage>();

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

    void ITakeDamage.TakeDamage(float damageAmount)
    {
        // Inflict damage to all damageables in range
        foreach (var damageable in Damageables)
        {
            damageable.TakeDamage(damageAmount);
        }
    }
}



