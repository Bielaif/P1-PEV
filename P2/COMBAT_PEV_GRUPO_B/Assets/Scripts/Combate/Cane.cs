using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Interfaces;

public class Cane : MonoBehaviour
{

    [SerializeField]
    private float AttackDelay;
    [SerializeField]
    private float Damage;
    [SerializeField]
    private DealDamage _DamageDealer;

    private Animator _animator;
    private bool _isAttacking;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _isAttacking = false;
    }
    private void OnAttack(InputValue value)
    {
        if (_animator.GetBool("WithCane") == true)
        {
         _animator.SetTrigger("Attack");
         StartCoroutine("Hit");     
        }

    }
    private IEnumerator Hit()
    {
        _isAttacking = true;
        yield return new WaitForSeconds(AttackDelay);
        foreach (var damageablesInArea in _DamageDealer.Damageables)
        {
            damageablesInArea.TakeDamage(Damage);
        }
        _isAttacking = false;

    }
}
