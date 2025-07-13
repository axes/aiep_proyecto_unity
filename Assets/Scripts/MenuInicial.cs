using UnityEngine;


// Importa el módulo para gestionar escenas en Unity
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public void Jugar()
    {
        // Carga la escena llamada "Nivel1"
        SceneManager.LoadScene("Nivel1");
    }

    public void IrAHistoria()
    {
        SceneManager.LoadScene("Historia");
    }

    public void Salir()
    {
        // Sale de la aplicación
        Application.Quit();
        
        // Deja un mensaje en la consola para indicar que se ha cerrado
        Debug.Log("Saliendo del juego...");

        // Si estás en el editor de Unity, también detiene la reproducción
        // Esto es útil para pruebas en el editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
