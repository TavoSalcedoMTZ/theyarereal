using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energia : MonoBehaviour
{
    public int numeroDeBaterias = 3;
    public float duracionBateria = 30f;
    private float bateriaRestante;
    private bool lamparaEncendida = false;

    public GameObject linternaSpotlight;
    public Text bateriasText;

    public float cooldownTiempo = 1f; 
    private float tiempoDesdeUltimoUso;

    void Start()
    {
        bateriaRestante = duracionBateria;
        linternaSpotlight.SetActive(false);
        ActualizarTextoBaterias();
        tiempoDesdeUltimoUso = cooldownTiempo; 
    }

    void Update()
    {
        tiempoDesdeUltimoUso += Time.deltaTime;

   
        if (Input.GetKeyDown(KeyCode.F) && tiempoDesdeUltimoUso >= cooldownTiempo)
        {

            if (lamparaEncendida)
            {
                ApagarLampara();
            }
            else
            {
                EncenderLampara();
            }
        }

    
        if (lamparaEncendida)
        {
            ConsumirBateria(Time.deltaTime);
        }
    }

    public void EncenderLampara()
    {
        if (numeroDeBaterias > 0)
        {
            lamparaEncendida = true;
            linternaSpotlight.SetActive(true);
            tiempoDesdeUltimoUso = 0f; 
        }
        else
        {
            Debug.Log("No hay bater�as restantes.");
        }
    }

    public void ApagarLampara()
    {
        lamparaEncendida = false;
        linternaSpotlight.SetActive(false);
        tiempoDesdeUltimoUso = 0f;
    }

    private void ConsumirBateria(float tiempo)
    {
        if (bateriaRestante > 0)
        {
            bateriaRestante -= tiempo;

            if (bateriaRestante <= 0)
            {
                numeroDeBaterias--;
                ActualizarTextoBaterias();

                if (numeroDeBaterias > 0)
                {
                    bateriaRestante = duracionBateria;
                }
                else
                {
                    ApagarLampara();
                    Debug.Log("Se han agotado todas las bater�as.");
                }
            }
        }
    }

    private void ActualizarTextoBaterias()
    {
        bateriasText.text = "Bater�as: " + numeroDeBaterias;
    }
}
