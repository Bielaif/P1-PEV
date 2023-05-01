using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthSystem _healthSystem;
    [SerializeField] private Slider _healthBarSlider;

    private void OnEnable()
    {
        if (_healthSystem != null)
        {
            _healthSystem.onHit += UpdateHealthBar;
        }
    }

    private void OnDisable()
    {
        if (_healthSystem != null)
        {
            _healthSystem.onHit -= UpdateHealthBar;
        }
    }

    private void UpdateHealthBar(float healthFraction)
    {
        if (_healthBarSlider != null)
        {
            _healthBarSlider.value = healthFraction;
        }
    }
}



