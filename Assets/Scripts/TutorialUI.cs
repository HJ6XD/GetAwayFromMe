using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] GameObject pantallaDeInicio;
    [SerializeField] GameObject pantallaDeControles;

    public void ActivateControlScreen()
    {
        pantallaDeControles.SetActive(true);
        pantallaDeInicio.SetActive(false);
    }
    public void ActivateStartScreen()
    {
        pantallaDeControles.SetActive(false);
        pantallaDeInicio.SetActive(true);
    }
}
