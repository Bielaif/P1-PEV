using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider _slider;
    private HealthSystem _healthSystem;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _healthSystem = GetComponentInParent<HealthSystem>();
        _healthSystem.onHit += OnHit;
        _slider.maxValue = _healthSystem.MaxHealth;
        _slider.value = _slider.maxValue;
    }

    private void OnHit(float healthFraction)
    {
        _slider.value = _healthSystem._currentHealth;
    }
}




