using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class ProvaDmg : MonoBehaviour
{
    public KeyCode damageKey = KeyCode.J;
    public float damageAmount = 10f;

    private HealthSystem healthSystem;
    private DealDamage dealDamage;

    private void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        dealDamage = GetComponent<DealDamage>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(damageKey))
        {
            // Inflict damage to all damageables in range
            foreach (var damageable in dealDamage.Damageables)
            {
                damageable.TakeDamage(damageAmount);
            }
        }
    }
}

