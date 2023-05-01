using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDmg : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float attackDuration = 1.5f;

    private bool isAttacking = false;
    private float attackTimer = 0f;

    private void Update()
    {
        if (isAttacking)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackDuration)
            {
                isAttacking = false;
                attackTimer = 0f;
            }
        }

        animator.SetBool("isAttacking", isAttacking);
    }

    public void StartAttack()
    {
        isAttacking = true;
    }
}

