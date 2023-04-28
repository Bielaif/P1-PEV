using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Interfaces;

public class Cane : Weapon
{

    [SerializeField]
    private float AttackDelay;
    [SerializeField]
    private float Damage;
    [SerializeField]
    private DealDamage _DamageDealer;

    private bool _isAttacking;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Weapon tempWT = gameObject.GetComponentInParent<Weapon>();
        if (WeaponType.Cane == tempWT.CurrentWeaponType)
            StateCheck();
    }

    private void StateCheck()
    {
        _animator.SetLayerWeight(1, 0);
        _animator.SetBool("WithPistol", false);
        _animator.SetBool("WithCane", true);
    }

    public override void OnAttack(InputValue value)
    {
        Weapon tempWT = gameObject.GetComponentInParent<Weapon>();
        if (WeaponType.Cane == tempWT.CurrentWeaponType)
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
