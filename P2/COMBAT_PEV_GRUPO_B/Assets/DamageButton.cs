using UnityEngine;
using UnityEngine.UI;
using Interfaces;

public class DamageButton : MonoBehaviour
{
    [SerializeField] private HealthSystem _healthSystem;
    [SerializeField] private float _damageAmount = 10f;
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(InflictDamage);
    }

    private void InflictDamage()
    {
        _healthSystem.TakeDamage(_damageAmount);
    }
}

