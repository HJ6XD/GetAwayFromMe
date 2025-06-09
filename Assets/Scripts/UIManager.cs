using UnityEngine;
using TMPro;

public class ControladorUI : MonoBehaviour
{
    public static ControladorUI uiInstance;

    private void Awake()
    {
        if (uiInstance != null && uiInstance != this)
            Destroy(this);
        else
            uiInstance = this;
    }

    [Header("Textos")]
    [SerializeField] TextMeshProUGUI lifetext;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeText;
    
    [SerializeField] TextMeshProUGUI gameOverScoreText;
    [SerializeField] TextMeshProUGUI gameOverTimeText;

    [Header("GameObjects")]
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject playerUI;

    public void UpdateLifeText(int life)
    {
        lifetext.text = life.ToString() + "/250";
    }
    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }
    

    public void UpdateTimerText(string _time)
    {
        timeText.text = _time;
    }

    public void GameOverScreen()
    {
        gameOverScreen.SetActive(true);
        gameOverScoreText.text = "Your Score: " + ScoreManager.scoreInstance.curScore.ToString();
        gameOverTimeText.text = "Time Survived: " + Timer.timerInstance.TimeSurvived.ToString("F2");
        playerUI.SetActive(false);
    }
}
