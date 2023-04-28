using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Weapon : MonoBehaviour
{
    
    protected Animator _animator;
    public WeaponType CurrentWeaponType;

    [SerializeField]
    private GameObject Cuerpo;

    [SerializeField]
    private GameObject WeapCane;

    [SerializeField]
    private GameObject WeapPistol;

    private void Update()
    {
        Swap();
        Debug.Log(CurrentWeaponType);
        
    }
    public virtual void OnAttack(InputValue value)
    {

    }
    private void Swap()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            CurrentWeaponType = WeaponType.Cane;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            CurrentWeaponType = WeaponType.Pistol;
        ChangeWeapon();
    }

    private void ChangeWeapon()
    {
        WeapCane.SetActive(false);
        WeapPistol.SetActive(false);
        if (CurrentWeaponType == WeaponType.Cane)
        WeapCane.SetActive(true);
        if (CurrentWeaponType == WeaponType.Pistol)
        WeapPistol.SetActive(true);
    }

    public enum WeaponType { Cane, Pistol };

}
