using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Interfaces;

public class LaserGun : Pistol
{

    [SerializeField]
    LayerMask WhatIsShootable;
    [SerializeField]
    float RendererKill;
    [SerializeField]
    float Rango;

    LineRenderer _lineRenderer;
    
    Vector3 _lasthit;

    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _animator = GetComponent<Animator>();
    }

    public override void OnAttack(InputValue value)
    {

        if (_animator.GetBool("WithLaser") == true && _animator.GetBool("InAnimamtion") == false)
            TryShoot();
    }




    public override void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(FirePoint.position, FirePoint.forward, out hit, Rango, WhatIsShootable))
        {
            Debug.Log(hit.transform.name);
            _lasthit = hit.point;
            SetRenderer();
            var damageReceiver = hit.transform.GetComponent<ITakeDamage>();
            if (damageReceiver != null)
            {
                damageReceiver.TakeDamage(400);

            }

        }
        else
        {
            MissShot();
        }
    }

    private void MissShot()
    {
        _lineRenderer.startColor = Color.red;
        _lineRenderer.endColor = Color.gray;
        Vector3 EndPoint = transform.position + FirePoint.forward * Rango;
        _lineRenderer.SetPosition(0, FirePoint.position);
        _lineRenderer.SetPosition(1, EndPoint);
        Invoke("KillMySelf", RendererKill);
    }

    void SetRenderer()
    {
        _lineRenderer.startColor = Color.green;
        _lineRenderer.endColor = Color.gray; ;
        _lineRenderer.SetPosition(0, FirePoint.position);
        _lineRenderer.SetPosition(1, _lasthit);
        Invoke("KillMySelf", RendererKill);
    }
    void KillMySelf()
    {
        _lineRenderer.SetPosition(0, FirePoint.position);
        _lineRenderer.SetPosition(1, FirePoint.position);
    }

}
