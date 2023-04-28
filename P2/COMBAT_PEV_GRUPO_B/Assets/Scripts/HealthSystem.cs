using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour, ITakeDamage
{
    [SerializeField] public float _maxHealth = 100f;
    //[SerializeField] private float _knockbackStrenght = 10f;
    public float _currentHealth;
    public bool _isAlive;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private GameObject deathPanel;

    public float MaxHealth { get { return _maxHealth; } }

    private void Start()
    {
        _currentHealth = _maxHealth;
        _isAlive = true;
        //_healthSlider = GetComponentInChildren<Slider>();
    }

    public delegate void OnHit(float healthFraction);
    public OnHit onHit;

    private void UpdateHealthBar()
    {
        // calculate health fraction
        float healthFraction = _currentHealth / _maxHealth;

        // set fill amount of health bar
        //_healthBarFill.fillAmount = healthFraction;

        // set value of slider
        if (_healthSlider != null)
        {
            _healthSlider.value = healthFraction;
        }
    }


    public void TakeDamage(float damageAmount)
    {
        // subtract damage from current health
        _currentHealth -= damageAmount;

        // update health bar
        UpdateHealthBar();

        // invoke OnHit delegate
        if (onHit != null)
        {
            onHit(_currentHealth / _maxHealth);
        }

        // check if health is zero or below
        if (_currentHealth <= 0)
        {
            _isAlive = false;
            deathPanel.SetActive(true);


        }
    }


    public void Heal(float healAmount)
    {
     
        if (_isAlive && _currentHealth < _maxHealth)
        {
            _currentHealth = Mathf.Min(_currentHealth + healAmount, _maxHealth);
            UpdateHealthBar();
            Debug.Log($"Enemy have {_currentHealth}");
        }
       

        if (!_isAlive && deathPanel.activeSelf)
        {
            deathPanel.SetActive(false);
            _isAlive = true;
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
