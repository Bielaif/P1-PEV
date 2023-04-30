using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Animator))]
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
    private void OnAnimatorIK(int layerIndex)
    {
        _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, Weight);
        _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, Weight);
        _animator.SetIKPosition(AvatarIKGoal.RightHand, RightHandTarget.position);
        _animator.SetIKPosition(AvatarIKGoal.LeftHand, LeftHandTarget.position);
    }
}
