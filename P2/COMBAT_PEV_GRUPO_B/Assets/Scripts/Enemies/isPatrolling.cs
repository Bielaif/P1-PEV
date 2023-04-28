using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPatrolling : MonoBehaviour
{
    public Transform[] patrolPoints;        // Lista de puntos de patrulla
    public float moveSpeed = 3.5f;            // Velocidad de movimiento
    public Animator animator;               // Referencia al componente Animator del enemigo

    private int currentPointIndex;          // Índice del punto de patrulla actual
    private Vector3 currentTarget;          // Punto de patrulla actual
    private bool iSpatrolling;              // Variable para indicar si el enemigo está en estado de patrulla o no

    private void Start()
    {
        // Obtener el punto de patrulla inicial
        currentPointIndex = 0;
        currentTarget = patrolPoints[currentPointIndex].position;
    }

    private void Update()
    {
        // Obtener el valor actual del parámetro "isPatrolling" del Animator
        iSpatrolling = animator.GetBool("isPatrolling");

        // Si el enemigo está en estado de patrulla, moverlo hacia el punto de patrulla actual
        if (iSpatrolling)
        {
            // Calcular la dirección de movimiento hacia el punto de patrulla actual
            Vector3 direction = currentTarget - transform.position;
            direction.y = 0f; // asegurarse de que la dirección en y sea 0 para evitar movimiento vertical

            // Si el enemigo ha llegado al punto de patrulla actual, seleccionar el siguiente punto de patrulla
            if (direction.magnitude < 0.1f)
            {
                currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
                currentTarget = patrolPoints[currentPointIndex].position;
                SetNextPatrolPoint();
            }

            // Gira el enemigo hacia el punto de patrulla actual
            Vector3 targetDirection = currentTarget - transform.position;
            targetDirection.y = 0f;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);

            // Mover al enemigo hacia el punto de patrulla actual
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
    private void SetNextPatrolPoint()
    {
        // Incrementar el índice del punto de patrulla actual
        currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;

        // Actualizar el punto de patrulla actual
        currentTarget = patrolPoints[currentPointIndex].position;

        // Apuntar hacia el nuevo punto de patrulla
        Vector3 direction = currentTarget - transform.position;
        direction.y = 0f;
        transform.rotation = Quaternion.LookRotation(direction);
    }

}









