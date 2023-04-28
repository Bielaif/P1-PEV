using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoll : MonoBehaviour
{
    public float rollSpeed = 10f;       // Velocidad del roll
    public float rollDuration = 0.8f;   // Duración del roll
    public float rollCooldown = 0.5f;     // Tiempo de enfriamiento del roll
    public float groundCheckDistance = 0.2f;  // Distancia a la que se comprueba si el jugador está en el suelo
    public LayerMask groundLayer;       // Capa del suelo

    private Animator anim;              // Referencia al componente Animator del jugador
    private float rollTimer;            // Temporizador del roll
    private float rollCooldownTimer;    // Temporizador de enfriamiento del roll
    private bool isRolling;             // Booleano que indica si el jugador está rodando

    private void Start()
    {
        // Obtener el componente Animator del jugador
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Obtener la entrada del jugador para el roll
        bool rollInput = Input.GetKeyDown(KeyCode.Space);

        // Si se detecta la entrada de roll y el roll no está en enfriamiento, entrar en estado Roll
        if (rollInput && rollCooldownTimer <= 0f)
        {
            isRolling = true;
            rollTimer = rollDuration;
            rollCooldownTimer = rollCooldown;
            anim.SetBool("Roll", true);
        }

        // Si el jugador está en estado Roll, moverlo en la dirección en la que estaba mirando antes de entrar en estado Roll
        if (isRolling)
        {
            // Calcular la dirección de movimiento basándose en la dirección de la cámara
            Vector3 movement = Camera.main.transform.forward * rollSpeed * Time.deltaTime;

            // Comprobar si el jugador está en el suelo
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance, groundLayer))
            {
                // Si está en el suelo, mover al jugador en la dirección calculada
                transform.position += movement;

                // Restar el temporizador del roll
                rollTimer -= Time.deltaTime;

                // Si se acaba el tiempo del roll, salir del estado Roll
                if (rollTimer <= 0f)
                {
                    isRolling = false;
                    anim.SetBool("Roll", false);
                }
            }
        }

        // Restar el temporizador de enfriamiento del roll
        if (rollCooldownTimer > 0f)
        {
            rollCooldownTimer -= Time.deltaTime;
        }
    }
}

