using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class EnemyDmg : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private float attackdelay = 1.5f;

    [SerializeField]
    private float damage;

    private float attackTimer = 0f;
    private bool DealDamage;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (_animator.GetBool("Attack"))
        {
            AttackTime();
        }
    }
    private void AttackTime()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackdelay)
        {
            DealDamage = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        var damageReciever = other.GetComponent<ITakeDamage>();
        if (damageReciever != null && DealDamage)
        {
            damageReciever.TakeDamage(damage);
            DealDamage = false;
        }

    }
}


