using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour, ITakeDamage
{
    [SerializeField] public float maxHealth = 100f;
    public float currentHealth;
    public bool isPlayer = false;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private GameObject deathPanel;
    private bool isTakingDamage = false;
    
    public float MaxHealth { get { return maxHealth; } }

    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider.value = 1f;
    }

    public delegate void OnHit(float healthFraction);
    public OnHit onHit;

    private void UpdateHealthBar()
    {
        // calculate health fraction
        float healthFraction = currentHealth / maxHealth;

        // set value of slider
        if (!isTakingDamage && healthSlider != null)
        {
            healthSlider.value = healthFraction;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        Debug.Log("TakeDamage function called");
        // subtract damage from current health
        currentHealth -= damageAmount;

        // update health bar
        UpdateHealthBar();

        // invoke OnHit delegate
        if (onHit != null)
        {
            onHit(currentHealth / maxHealth);
        }

        // check if health is zero or below
        if (currentHealth <= 0)
        {
            if (isPlayer)
            {
                // Player death logic
                Debug.Log("Player has died!");
                deathPanel.SetActive(true);
            }
            else
            {
                // Enemy death logic
                Debug.Log("Enemy has died!");
                gameObject.SetActive(false);
            }
        }
        else
        {
            StartCoroutine(TakeDamageDelay());
        }
    }

    private IEnumerator TakeDamageDelay()
    {
        isTakingDamage = true;
        yield return new WaitForSeconds(0.5f);
        isTakingDamage = false;
    }

    public void Heal(float healAmount)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
            UpdateHealthBar();
        }

        if (deathPanel.activeSelf)
        {
            deathPanel.SetActive(false);
            currentHealth = maxHealth;
            gameObject.SetActive(true);
        }
    }
}






/*private void OnCollisionEnter(Collision collision)
{
    Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

    if(rb != null)
    {
        Vector3 direction = collision.transform.position + transform.position;
        direction.y = 0;

        rb.AddForce(direction.normalized * _knockbackStrenght, ForceMode.Impulse);
    }
}*/
