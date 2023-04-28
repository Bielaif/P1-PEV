using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cane : Weapon
{
    

    private bool _isAttacking;

    [SerializeField]
    private float AttackDelay;

    [SerializeField]
    private DealDamage _DamageDealer;

    [SerializeField]
    private float Damage;

    [SerializeField]
    private float KnockBackForce;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        

    }
    private void Update()
    {
 
        if (WeaponType.Cane == CurrentWeaponType)
            StateCheck();

        Debug.Log(CurrentWeaponType);
    }

    private void StateCheck()
    {
        _animator.SetLayerWeight(1, 0);
        _animator.SetBool("WithPistol", false);
        _animator.SetBool("WithCane", true);
    }

    public override void OnAttack(InputValue value)
    {
        if (WeaponType.Cane == CurrentWeaponType)
        {
        if (_isAttacking) return;
        StartCoroutine("Hit");
        _animator.SetTrigger("Attack");
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
