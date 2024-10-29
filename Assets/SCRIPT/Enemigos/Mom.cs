using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float moveSpeed = 2f;             // Velocidad de movimiento
    public float detectionRange = 5f;        // Rango de detecci�n del jugador
    public float attackRange = 1.5f;         // Rango de ataque
    public Transform player;                  // Referencia al jugador
    private Vector3 targetPosition;           // Posici�n objetivo para movimiento aleatorio

    private float nextMoveTime;

    void Start()
    {
        SetRandomTargetPosition();
    }

    void Update()
    {
<<<<<<< Updated upstream
        
        // Incrementar el �ngulo basado en el tiempo y la velocidad
        angle += speed * Time.deltaTime;
=======
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
>>>>>>> Stashed changes

        if (distanceToPlayer < attackRange)
        {
            AttackPlayer();
        }
        else if (distanceToPlayer < detectionRange)
        {
            ChasePlayer();
        }
        else
        {
            MoveRandomly();
        }
    }

<<<<<<< Updated upstream
        // Actualizar la posici�n del enemigo
        transform.position = new Vector3(x, transform.position.y, z);
        
=======
    void MoveRandomly()
    {
        if (Time.time >= nextMoveTime)
        {
            SetRandomTargetPosition();
            nextMoveTime = Time.time + Random.Range(2f, 5f); // Cambia de direcci�n cada 2-5 segundos
        }
        
        // Mueve al enemigo hacia la posici�n objetivo
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Si el enemigo llega a la posici�n objetivo, establece una nueva
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTargetPosition();
        }
    }

    void SetRandomTargetPosition()
    {
        float x = Random.Range(-5f, 5f);
        float z = Random.Range(-5f, 5f);
        targetPosition = new Vector3(x, transform.position.y, z);
    }

    void ChasePlayer()
    {
        // Mueve al enemigo hacia el jugador
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    void AttackPlayer()
    {
        // Aqu� puedes implementar la l�gica de ataque
        Debug.Log("Atacando al jugador!");
>>>>>>> Stashed changes
    }
}
