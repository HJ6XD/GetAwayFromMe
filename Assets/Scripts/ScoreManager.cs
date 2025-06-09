using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreInstance { get; private set; }

    public int curScore =0;

    private void Awake()
    {
        if (scoreInstance != null && scoreInstance != this)
            Destroy(this);
        else
            scoreInstance = this;
    }

    public void GainPoints(int points)
    {
        curScore += points;
        ControladorUI.uiInstance.UpdateScoreText(curScore);
    }
}
