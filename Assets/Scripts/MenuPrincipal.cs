using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Jugar()
    {
        SceneManager.LoadScene("NivelPrincipal");
    }

    // Update is called once per frame
    public void Salir()
    {
        Application.Quit();
    }
}
