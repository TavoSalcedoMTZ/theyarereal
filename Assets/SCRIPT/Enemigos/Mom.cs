using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mom : MonoBehaviour
{
    public float radius = 2f; // Radio del movimiento circular
    public float speed = 2f;  // Velocidad de movimiento
    private float angle = 0f; // Ángulo para el movimiento circular

    void Update()
    {
        
        // Incrementar el ángulo basado en el tiempo y la velocidad
        angle += speed * Time.deltaTime;

        // Calcular la nueva posición usando seno y coseno
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        // Actualizar la posición del enemigo
        transform.position = new Vector3(x, transform.position.y, z);
        
    }
}
