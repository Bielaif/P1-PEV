using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pistol : Weapon
{
    private void Start()
    {
        _animator = GetComponent<Animator>();
        

    }
    private void Update()
    {
        if(WeaponType.Pistol == CurrentWeaponType)
        StateCheck();

        Debug.Log(CurrentWeaponType);
    }

    private void StateCheck()
    {
        _animator.SetLayerWeight(1, 1);
        _animator.SetBool("WithCane", false);
        _animator.SetBool("WithPistol", true);
    }

    public override void OnAttack(InputValue value)
    {
        if (WeaponType.Pistol == CurrentWeaponType)
            Debug.Log("Bang");

    }
}
