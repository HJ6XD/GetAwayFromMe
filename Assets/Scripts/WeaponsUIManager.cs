using TMPro;
using UnityEngine;

public class WeaponsUIManager : MonoBehaviour
{
    public static WeaponsUIManager wuiInstance;

    private void Awake()
    {
        if (wuiInstance != null && wuiInstance != this)
            Destroy(this);
        else
            wuiInstance = this;
    }

    [SerializeField] TextMeshProUGUI bulletstext;
    [SerializeField] GameObject ARImage;
    [SerializeField] GameObject SGImage;
    [SerializeField] GameObject UZImage;
    public void UpdateCurBulText(int curbul, int maxbul)
    {
        bulletstext.text = curbul.ToString() + "/" + maxbul.ToString();
    }

    public void ChangeToAR()
    {
        ARImage.SetActive(true);
        SGImage.SetActive(false);
        UZImage.SetActive(false);
    }
    public void ChangeToSG()
    {
        ARImage.SetActive(false);
        SGImage.SetActive(true);
        UZImage.SetActive(false);
    }
    public void ChangeToUZ()
    {
        ARImage.SetActive(false);
        SGImage.SetActive(false);
        UZImage.SetActive(true);
    }

}
