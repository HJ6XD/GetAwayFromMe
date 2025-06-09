using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorEscenas : MonoBehaviour
{
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MenuInicial(string menu)
    {
        SceneManager.LoadScene(menu);
    }
    public void Salir()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
