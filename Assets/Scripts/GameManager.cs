using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;
    public int nodosRestantes;
    public GameObject panelVictoria;

    void Awake() { instancia = this; }
    
    void Start()
    {
        nodosRestantes = GameObject.FindGameObjectsWithTag("Energia").Length;
    }

    public void RecolectarNodo()
    {
        if (nodosRestantes <= 0)
        panelVictoria.SetActive(true);
    }
}