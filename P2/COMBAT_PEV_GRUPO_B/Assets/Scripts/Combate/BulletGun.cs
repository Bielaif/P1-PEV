using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletGun : Pistol
{
    [SerializeField]
    protected GameObject BulletPrefab;
    [SerializeField]
    protected float FireSpeed = 2;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }



    public override void OnAttack(InputValue value)
    {
        if (_animator.GetBool("WithPistol") == true && _animator.GetBool("InAnimation") == false)
        {
            TryShoot();
        }

    }

    public override void Shoot()
    {
        GameObject go = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        go.GetComponent<Rigidbody>().velocity = go.transform.forward * FireSpeed;
    }
}
