using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;            // Velocidad de movimiento del jugador
    public float turnSpeed = 15f;       // Velocidad de giro del jugador
    public LayerMask obstacleLayer;     // Capa de los obstáculos
    
    private Animator anim;              // Referencia al componente Animator del jugador
    private Collider playerCollider;    // Collider del jugador

    private void Start()
    {
        // Obtener el componente Animator del jugador
        anim = GetComponent<Animator>();
        
        // Obtener el collider del jugador
        playerCollider = GetComponent<Collider>();
    }

    private void Update()
    {
            // Obtener la entrada horizontal y vertical del jugador
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
        

        // Calcular la dirección de movimiento basándose en la entrada del jugador y la dirección de la cámara
        Vector3 movement = new Vector3(h, 0f, v);
        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0f;

        // Si el jugador se mueve, cambiar al estado IsMoving y mover el jugador
        if (movement.magnitude > 0.1f && !anim.GetBool("InAnimation"))
        {
            anim.SetBool("IsMoving", true);
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
            transform.position += movement.normalized * speed * Time.deltaTime;

           /*// Detectar obstáculos en la dirección de movimiento
            Collider[] hitColliders = Physics.OverlapBox(playerCollider.bounds.center + movement.normalized * (playerCollider.bounds.extents.magnitude + 0.01f), playerCollider.bounds.extents, playerCollider.transform.rotation, obstacleLayer);
            if (hitColliders.Length > 0)
            {
                // Mover al jugador hacia atrás para que no atraviese el obstáculo
                transform.position -= movement.normalized * speed * Time.deltaTime;
            }*/
        }
        // Si el jugador no se mueve, cambiar al estado !IsMoving
        else
        {
            anim.SetBool("IsMoving", false);
        }
    }

   /* private void OnDrawGizmosSelected()
    {
        // Dibujar la caja utilizada para detectar obstáculos
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(playerCollider.bounds.center, playerCollider.bounds.extents * 2 + new Vector3(0.02f, 0.02f, 0.02f));
    }*/
}





