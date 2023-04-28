using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pistol : Weapon
{
    [SerializeField]
    protected GameObject BulletPrefab;
    [SerializeField]
    protected Transform FirePoint;
    [SerializeField]
    protected float FireSpeed = 2;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Weapon tempWT = gameObject.GetComponentInParent<Weapon>();
        if (WeaponType.Pistol == tempWT.CurrentWeaponType)
            StateCheck();
    }

    private void StateCheck()
    {
        _animator.SetLayerWeight(1, 1);
        _animator.SetBool("WithCane", false);
        _animator.SetBool("WithPistol", true);
    }

    public override void OnAttack(InputValue value)
    {
        Weapon tempWT = gameObject.GetComponentInParent<Weapon>();
        if (WeaponType.Pistol == tempWT.CurrentWeaponType) 
        { 
        GameObject go = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        go.GetComponent<Rigidbody>().velocity = go.transform.right * FireSpeed;
        }

    }

    [SerializeField]
    Transform RightHandTarget;

    [SerializeField]
    [Range(0, 1)]
    float Weight;
    private void OnAnimatorIK(int layerIndex)
    {
        _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, Weight);
        _animator.SetIKPosition(AvatarIKGoal.RightHand, RightHandTarget.position);
    }
}
