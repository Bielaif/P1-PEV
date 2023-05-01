using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class HealthSystem : MonoBehaviour, ITakeDamage
{
    [SerializeField] public float _maxHealth = 100f;
    public float _currentHealth;
    public bool _isAlive;

    private float _lastHealth;

    public float MaxHealth { get { return _maxHealth; } }

    public void Start()
    {
        _currentHealth = _maxHealth;
        _lastHealth = _currentHealth;
        _isAlive = true;
    }

    public delegate void OnHit(float healthFraction);
    public OnHit onHit;

    public void UpdateHealthBar()
    {
        float healthFraction = _currentHealth / _maxHealth;

        _lastHealth = _currentHealth;
    }

    public virtual void TakeDamage(float damageAmount)
    {
        _currentHealth -= damageAmount;

        if (_currentHealth <= 0 && _isAlive)
        {
            Die();
        }

        if (_currentHealth != _lastHealth)
        {
            UpdateHealthBar();

            if (onHit != null)
            {
                onHit(_currentHealth / _maxHealth);
            }
        }
    }

    public virtual void Heal(float healAmount)
    {
        if (_isAlive && _currentHealth < _maxHealth)
        {
            _currentHealth = Mathf.Min(_currentHealth + healAmount, _maxHealth);
        }

        if (!_isAlive)
        {
            _isAlive = true;
        }

        if (_currentHealth != _lastHealth)
        {
            UpdateHealthBar();

            if (onHit != null)
            {
                onHit(_currentHealth / _maxHealth);
            }
        }
    }

    public virtual void Die()
    {
        _isAlive = false;
        gameObject.SetActive(false);
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
