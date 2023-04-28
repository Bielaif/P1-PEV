using UnityEngine;
using UnityEngine.UI;

public class HealthBarBysense : MonoBehaviour
{
    private HealthSystem _healthSystem;

    [SerializeField]
    private Slider _slider;

    void Start()
    {
        _healthSystem = GetComponent<HealthSystem>();
        if (_healthSystem == null)
        {
            Debug.LogError("No se ha encontrado el componente HealthSystem en este objeto o en su padre.");
        }
        else
        {
            _healthSystem.onHit += UpdateHealthBar;
            _slider.value = _healthSystem._currentHealth / _healthSystem._maxHealth;
        }
    }


    private void UpdateHealthBar(float healthFraction)
    {
        // update the value of the slider to reflect the new health fraction
        _slider.value = _healthSystem._currentHealth;

        // optional: you can add an animation to the slider if you want
        // e.g. using a Tween library like DOTween
        // DOTween.To(() => _healthBarSlider.value, x => _healthBarSlider.value = x, _healthSystem.CurrentHealth, 0.5f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            // deal damage to the character
            _healthSystem.TakeDamage(20f);
        }
    }
}

