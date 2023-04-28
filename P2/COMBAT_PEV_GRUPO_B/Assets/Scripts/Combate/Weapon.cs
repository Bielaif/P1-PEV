using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Weapon : MonoBehaviour
{
    protected Animator _animator;
    protected WeaponType CurrentWeaponType;

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
    }
    protected enum WeaponType { Cane, Pistol };

}
