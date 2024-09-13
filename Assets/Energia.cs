using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Energia : MonoBehaviour
{
    public int numeroDeBaterias = 3; 
    public float duracionBateria = 30f; 
    private float bateriaRestante; 
    private bool lamparaEncendida = false; 

    void Start()
    {
   
        bateriaRestante = duracionBateria;
    }

    void Update()
    {
    
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
        }
        else
        {
            Debug.Log("No hay baterías restantes.");
        }
    }

   
    public void ApagarLampara()
    {
        lamparaEncendida = false;
    }


    private void ConsumirBateria(float tiempo)
    {
        if (bateriaRestante > 0)
        {
            bateriaRestante -= tiempo;

            if (bateriaRestante <= 0)
            {
             
                numeroDeBaterias--;
                if (numeroDeBaterias > 0)
                {
                    bateriaRestante = duracionBateria;
                }
                else
                {
                    ApagarLampara();
                    Debug.Log("Se han agotado todas las baterías.");
                }
            }
        }
    }
}
