using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pistol : MonoBehaviour
{
    [SerializeField]
    protected Transform FirePoint;
    [SerializeField]
    protected float CoolDownTime;

    protected float _lastShootTime;
    protected Animator _animator;
    public virtual void OnAttack(InputValue value)
    {
        TryShoot();
    }
    protected bool CanShoot()
    {
        return (_lastShootTime + CoolDownTime) <= Time.time;
    }
    protected void TryShoot()
    {
        if (CanShoot())
            Shoot();
        _lastShootTime = Time.deltaTime;
    }
    public virtual void Shoot()
    {
        
    }
}
