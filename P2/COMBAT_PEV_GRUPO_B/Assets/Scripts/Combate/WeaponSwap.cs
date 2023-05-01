using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class WeaponSwap : MonoBehaviour
{
    
    protected Animator _animator;
    public WeaponType CurrentWeaponType;

    [SerializeField]
    private GameObject WeapCane;
    [SerializeField]
    private GameObject WeapPistol;

    private void Start()
    {
        _animator = GetComponent<Animator>();

    }
    private void Update()
    {
        Swap();
        Debug.Log(CurrentWeaponType);
        
    }

    private void Swap()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            CurrentWeaponType = WeaponType.Cane;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            CurrentWeaponType = WeaponType.Pistol;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            CurrentWeaponType = WeaponType.Laser;
        ChangeWeapon();
        ChangeState();
    }

    private void ChangeState()
    {
        if (CurrentWeaponType == WeaponType.Cane)
        {
            SetCaneOn();
        }
        else if (CurrentWeaponType == WeaponType.Pistol)
        {
            SetPistolOn();
        }
        else if (CurrentWeaponType == WeaponType.Laser)
        {
            SetLaserOn();
        }
    }

    private void SetLaserOn()
    {
        _animator.SetLayerWeight(1, 1);
        _animator.SetBool("WithCane", false);
        _animator.SetBool("WithLaser", true);
        _animator.SetBool("WithPistol", false);
    }

    private void SetPistolOn()
    {
        _animator.SetLayerWeight(1, 1);
        _animator.SetBool("WithCane", false);
        _animator.SetBool("WithLaser", false);
        _animator.SetBool("WithPistol", true);
    }

    private void SetCaneOn()
    {
        _animator.SetLayerWeight(1, 0);
        _animator.SetBool("WithPistol", false);
        _animator.SetBool("WithLaser", false);
        _animator.SetBool("WithCane", true);
    }

    private void ChangeWeapon()
    {
        WeapCane.SetActive(false);
        WeapPistol.SetActive(false);
        if (CurrentWeaponType == WeaponType.Cane)
        WeapCane.SetActive(true);
        if (CurrentWeaponType == WeaponType.Pistol || CurrentWeaponType == WeaponType.Laser)
        WeapPistol.SetActive(true);
    }

    public enum WeaponType { Cane, Pistol, Laser };

}
