using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class HealDamage : MonoBehaviour
{
    [SerializeField] private float _healAmount = 20f;
    
    private void OnTriggerEnter(Collider other)
    {
        var health = other.GetComponent<HealthSystem>();

        if (health != null && health._currentHealth < health._maxHealth)
        {
            health.Heal(_healAmount);
            Destroy(gameObject);
        }
    }

}