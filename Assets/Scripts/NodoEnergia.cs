using UnityEngine;

public class NodoEnergia : MonoBehaviour
{
    public float amplitud = 0.5f; //que tan alto y bajo se mueve (altura maxima del objeto)
    public float velocidad = 2f;  //que tan rapido hace el ciclo de arriba a abjao
    private Vector3 posicionInicial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instancia.nodosRestantes--;
            GameManager.instancia.RecolectarNodo();
            Destroy(gameObject);
        }
    }


    void Update()
        {
            // Movimiento vertical oscilante
        float desplazamientoY = posicionInicial.y + Mathf.Sin(Time.time * velocidad) * amplitud;

            transform.position = new Vector3(posicionInicial.x, posicionInicial.y + 
            desplazamientoY, posicionInicial.z);
        }
        }

