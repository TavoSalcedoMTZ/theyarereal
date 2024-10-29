using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mom : MonoBehaviour
{
    public float radius = 2f; // Radio del movimiento circular
    public float speed = 2f;  // Velocidad de movimiento
    private float angle = 0f; // �ngulo para el movimiento circular

    void Update()
    {
        
        // Incrementar el �ngulo basado en el tiempo y la velocidad
        angle += speed * Time.deltaTime;

        // Calcular la nueva posici�n usando seno y coseno
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        // Actualizar la posici�n del enemigo
        transform.position = new Vector3(x, transform.position.y, z);
        
    }
}
