using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visionDetection : MonoBehaviour
{
    [SerializeField] Transform castPoint;
    [SerializeField] Transform _player;
    [SerializeField] [Range(0, 10)] float detectionRange = 10;
    [SerializeField] [Range(0, 120)] float FOV = 90;
    [SerializeField] LayerMask whatIsWall;
    [SerializeField] Animator anim;
    
    public bool isChasing = false;
    private float timeOutOfVision = 0f;
    private float timeLimitOutOfVision = 5f;
    private bool isWaiting = false;
    private float waitTime = 3f;
    private float currentWaitTime = 0f;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }

    // Update is called once per frame
    void Update()
    {
        if (isChasing)
        {
            anim.SetBool("isPatrolling", false);
            anim.SetBool("isChasing", true);

            if (isInRange())
            {
                if (isInFOV())
                {
                    if (!isBlocked())
                    {
                        timeOutOfVision = 0f;

                        // Agrega la funcionalidad de ataque si el jugador está cerca
                        if (Vector3.Distance(transform.position, _player.position) < 2f)
                        {
                            anim.SetTrigger("Attack");
                            anim.SetBool("isChasing", false);
                            
                        }
                        else
                        {
                            anim.SetBool("isChasing", true);
                        }
                    }
                }
                else
                {
                    timeOutOfVision += Time.deltaTime;
                    if (timeOutOfVision >= timeLimitOutOfVision)
                    {
                        isChasing = false;
                        isWaiting = true;
                        currentWaitTime = 0f;
                    }
                }
            }
            else
            {
                isChasing = false;
                isWaiting = true;
                currentWaitTime = 0f;
            }
        }
        else
        {
            anim.SetBool("isChasing", false);

            if (!isWaiting)
            {
                anim.SetBool("isPatrolling", true);
            }
            else
            {
                currentWaitTime += Time.deltaTime;
                if (currentWaitTime >= waitTime)
                {
                    isWaiting = false;
                }
            }

            if (isInRange() && isInFOV() && !isBlocked())
            {
                isChasing = true;
            }
        }
    }

    private bool isBlocked()
    {
        Vector3 direction = _player.position - transform.position;
        if (Physics.Raycast(castPoint.position, direction, out RaycastHit hit, detectionRange, whatIsWall))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        return false;
    }

    private bool isInFOV()
    {
        float halfFOV = FOV / 2;
        Vector3 a = transform.forward;
        Vector3 b = _player.position - transform.position;
        float playerAngle = Vector3.Angle(a, b);

        return playerAngle <= halfFOV;
    }

    private bool isInRange()
    {
        if (_player == null)
        {
            return false;
        }
        return Vector3.Distance(transform.position, _player.position) < detectionRange;
    }

}
