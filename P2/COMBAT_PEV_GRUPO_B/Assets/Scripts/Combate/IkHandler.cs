using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkHandler : MonoBehaviour
{
    private Animator _animator;

    [SerializeField]
    Transform RightHandTarget;
    [SerializeField]
    Transform LeftHandTarget;

    [SerializeField]
    [Range(0, 1)]
    float Weight;

    float _origWeight;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _origWeight = Weight;
    }
    private void Update()
    {
        
        if (_animator.GetBool("InAnimation") == true || _animator.GetBool("WithCane") == true)
        {
            Weight = 0;
        }
        else
        {
            Weight = _origWeight;
        }
    }
    private void OnAnimatorIK(int layerIndex)
    {
        _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, Weight);
        _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, Weight);
        _animator.SetIKPosition(AvatarIKGoal.RightHand, RightHandTarget.position);
        _animator.SetIKPosition(AvatarIKGoal.LeftHand, LeftHandTarget.position);
    }
}
