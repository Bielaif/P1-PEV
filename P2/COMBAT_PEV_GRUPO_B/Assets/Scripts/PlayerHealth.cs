using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerHealth : HealthSystem
{
    // Add any additional properties or methods specific to the player here

    public new void Start()
    {
        base.Start(); // Call the base Start method
        // Additional initialization code for PlayerHealth
    }


    private void Update()
    {
        // Add any additional update logic for the player here
    }

    public override void TakeDamage(float damageAmount)
    {
        // Call the base class TakeDamage method to handle damage
        base.TakeDamage(damageAmount);

        // Add any additional player-specific behavior when taking damage here
    }

    public override void Heal(float healAmount)
    {
        // Call the base class Heal method to handle healing
        base.Heal(healAmount);

        // Add any additional player-specific behavior when healing here
    }

    public override void Die()
    {
        base.Die();
        // additional code for player death behavior
    }

}