using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCamera : MonoBehaviour
{
    public Transform target;    // Referencia al transform del jugador
    public float distance = 10f;    // Distancia de la cámara al jugador
    public float height = 10f;  // Altura de la cámara sobre el jugador
    public float rotation = -90f;    // Rotación de la cámara en torno al eje y

    private void LateUpdate()
    {
        // Calcular la posición de la cámara basándose en la posición y rotación del jugador
        Vector3 position = target.position;
        position -= Quaternion.Euler(0f, rotation, 0f) * Vector3.forward * distance;
        position.y = height;
        transform.position = position;

        // Hacer que la cámara apunte al jugador
        transform.LookAt(target.position);
    }
}

