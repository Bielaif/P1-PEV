using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CombatScript : MonoBehaviour
{
    private Animator _animator;
    private bool _isAttacking;

    [SerializeField]
    private float AttackDelay;

    [SerializeField]
    private DealDamage _DamageDealer;

    [SerializeField]
    private float Damage;

    [SerializeField]
    private float KnockBackForce;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void OnAttack(InputValue value)
    {
        if (_isAttacking) return;
        StartCoroutine("Hit");
        _animator.SetTrigger("Attack");
        
    }

    /*public void OnBlock(InputValue value)
    {
        _animator.SetTrigger("Block");
    }*/

   /* public void OnRoll(InputValue value)
    {
        _animator.SetTrigger("Roll");
    }*/
    private IEnumerator Hit()
    {
        _isAttacking = true;
        yield return new WaitForSeconds(AttackDelay);
        foreach(var damageablesInArea in _DamageDealer.Damageables)
        {
            damageablesInArea.TakeDamage(Damage);
        }
        _isAttacking = false;

        }
}
